using System;
using System.Collections.Generic;
using System.Globalization;

namespace URAX
{
    #region ParseTreeEvaluator
    // rootlevel of the node tree
    [Serializable]
    public partial class ParseTreeEvaluator : ParseTree
    {

        public Context Context { get; private set; }

        public ParseTreeEvaluator() : base()
        {
        }

        public ParseTreeEvaluator(Context context)
            : base()
        {
            Context = context;
        }

        /// <summary>
        /// required to override this function from base otherwise the parsetree will consist of incorrect types of nodes
        /// </summary>
        /// <param name="token"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public override ParseNode CreateNode(Token token, string text)
        {
            ParseTreeEvaluator node = new ParseTreeEvaluator();
            node.Token = token;
            node.text = text;
            node.Parent = this;
            return node;
        }

        protected override object EvalStart(ParseTree tree, params object[] paramlist)
        {
            return this.GetValue(tree, TokenType.Expression, 0);
        }

        protected override object EvalUnaryExpression(ParseTree tree, params object[] paramlist)
        {
            TokenType type = this.nodes[0].Token.Type;
            if (type == TokenType.PrimaryExpression)
                return this.GetValue(tree, TokenType.PrimaryExpression, 0);

            if (type == TokenType.MINUS)
            {
                object val = this.GetValue(tree, TokenType.UnaryExpression, 0);
                if (val is double)
                    return -((double)val);

                tree.Errors.Add(new ParseError("Illegal UnaryExpression format, cannot interpret minus " + val, 1095, this));
                return null;
            }
            else if (type == TokenType.PLUS)
            {
                object val = this.GetValue(tree, TokenType.UnaryExpression, 0);
                return val;
            }
            else if (type == TokenType.NOT)
            {
                object val = this.GetValue(tree, TokenType.UnaryExpression, 0);
                if (val is bool)
                    return !((bool)val);

                tree.Errors.Add(new ParseError("Illegal UnaryExpression format, cannot interpret negate " + val, 1098, this));
                return null;
            }
            
            Errors.Add(new ParseError("Illegal UnaryExpression format", 1099, this));
            return null;

        }

        protected override object EvalParams(ParseTree tree, params object[] paramlist)
        {
            List<object> parameters = new List<object>();
            for (int i = 0; i < nodes.Count; i += 2)
            {
                if (nodes[i].Token.Type == TokenType.Expression)
                {
                    object val = nodes[i].Eval(tree, paramlist);
                    parameters.Add(val);
                }
            }
            return parameters;
        }

        protected override object EvalFunction(ParseTree tree, params object[] paramlist)
        {
            ParseNode funcNode = this.nodes[0];
            ParseNode paramNode = this.nodes[2];

            ParseTreeEvaluator root = tree as ParseTreeEvaluator;
            if (root == null)
            {
                tree.Errors.Add(new ParseError("Invalid parser used", 1040, this));
                return null;
            }
            if (root.Context == null)
            {
                tree.Errors.Add(new ParseError("No context defined", 1041, this));
                return null;
            }
            if (root.Context.CurrentStackSize > 50)
            {
                tree.Errors.Add(new ParseError("Stack overflow: " + funcNode.Token.Text + "()", 1046, this));
                return null;
            }
            string key = funcNode.Token.Text.ToLowerInvariant();
            if (!root.Context.Functions.ContainsKey(key))
            {
                tree.Errors.Add(new ParseError("Fuction not defined: " + funcNode.Token.Text + "()", 1042, this));
                return null;
            }

            // retrieves the function from declared functions
            Function func = root.Context.Functions[key];

            // evaluate the function parameters
            object[] parameters = new object[0];
            if (paramNode.Token.Type == TokenType.Params)
                parameters = (paramNode.Eval(tree, paramlist) as List<object>).ToArray();
            if (parameters.Length < func.MinParameters)
            {
                tree.Errors.Add(new ParseError("At least " + func.MinParameters.ToString() + " parameter(s) expected", 1043, this));
                return null; // illegal number of parameters
            }
            else if (parameters.Length > func.MaxParameters)
            {
                tree.Errors.Add(new ParseError("No more than " + func.MaxParameters.ToString() + " parameter(s) expected", 1044, this));
                return null; // illegal number of parameters
            }
            else
            return func.Eval(parameters, root);
        }

        protected override object EvalVariable(ParseTree tree, params object[] paramlist)
        {
            ParseTreeEvaluator root = tree as ParseTreeEvaluator;
            if (root == null)
            {
                tree.Errors.Add(new ParseError("Invalid parser used", 1040, this));
                return null;
            }
            if (root.Context == null)
            {
                tree.Errors.Add(new ParseError("No context defined", 1041, this));
                return null;
            }

            string key = this.nodes[0].Token.Text;
            // first check if the variable was declared in scope of a function
            if (root.Context.CurrentScope != null && root.Context.CurrentScope.ContainsKey(key))
                return root.Context.CurrentScope[key];

            // if not in scope of a function
            // next check if the variable was declared as a global variable
            if (root.Context.Globals != null && root.Context.Globals.ContainsKey(key))
                return root.Context.Globals[key];

            //variable not found
            tree.Errors.Add(new ParseError("Variable not defined: " + key, 1039, this));
            return null;
        }

        protected override object EvalPrimaryExpression(ParseTree tree, params object[] paramlist)
        {
            TokenType type = this.nodes[0].Token.Type;
            if (type == TokenType.Function)
                return this.GetValue(tree, TokenType.Function, 0);
            else if (type == TokenType.Literal)
                return this.GetValue(tree, TokenType.Literal, 0);
            else if (type == TokenType.ParenthesizedExpression)
                return this.GetValue(tree, TokenType.ParenthesizedExpression, 0);
            else if (type == TokenType.Variable)
                return this.GetValue(tree, TokenType.Variable, 0);
           
            tree.Errors.Add(new ParseError("Illegal EvalPrimaryExpression format", 1097, this));
            return null;
        }

        protected override object EvalParenthesizedExpression(ParseTree tree, params object[] paramlist)
        {
            return this.GetValue(tree, TokenType.Expression, 0);
        }

        protected override object EvalPowerExpression(ParseTree tree, params object[] paramlist)
        {
            object result = this.GetValue(tree, TokenType.UnaryExpression, 0);

            // IMPORTANT: scanning and calculating the power is done from Left to Right.
            // this is conform the Excel evaluation of power, but not conform strict mathematical guidelines
            // this means that a^b^c evaluates to (a^b)^c  (Excel uses the same kind of evaluation)
            // stricly mathematical speaking a^b^c should evaluate to a^(b^c) (therefore calculating the powers from Right to Left)
            for (int i = 1; i < nodes.Count; i += 2)
            {
                Token token = nodes[i].Token;
                object val = nodes[i + 1].Eval(tree, paramlist);
                if (token.Type == TokenType.POWER)
                    result = Math.Pow(Convert.ToDouble(result), Convert.ToDouble(val));
            }

            return result;
        }

        protected override object EvalMultiplicativeExpression(ParseTree tree, params object[] paramlist)
        {
            object result = this.GetValue(tree, TokenType.PowerExpression, 0);
            for (int i = 1; i < nodes.Count; i += 2)
            {
                Token token = nodes[i].Token;
                object val = nodes[i + 1].Eval(tree, paramlist);
                if (token.Type == TokenType.ASTERIKS)
                    result = Convert.ToDouble(result) * Convert.ToDouble(val);
                else if (token.Type == TokenType.SLASH)
                    result = Convert.ToDouble(result) / Convert.ToDouble(val);
                else if (token.Type == TokenType.PERCENT)
                    result = Convert.ToDouble(result) % Convert.ToDouble(val);
            }

            return result;
        }

        protected override object EvalAdditiveExpression(ParseTree tree, params object[] paramlist)
        {
            object result = this.GetValue(tree, TokenType.MultiplicativeExpression, 0);
            for (int i = 1; i < nodes.Count; i += 2)
            {
                Token token = nodes[i].Token;
                object val = nodes[i + 1].Eval(tree, paramlist);
                if (token.Type == TokenType.PLUS)
                    result = Convert.ToDouble(result) + Convert.ToDouble(val);
                else if (token.Type == TokenType.MINUS)
                    result = Convert.ToDouble(result) - Convert.ToDouble(val);
            }

            return result;
        }

        protected override object EvalConcatEpression(ParseTree tree, params object[] paramlist)
        {
            object result = this.GetValue(tree, TokenType.AdditiveExpression, 0);
            for (int i = 1; i < nodes.Count; i += 2)
            {
                Token token = nodes[i].Token;
                object val = nodes[i + 1].Eval(tree, paramlist);
                if (token.Type == TokenType.AMP)
                    result = Convert.ToString(result) + Convert.ToString(val);
            }
            return result;
        }

        protected override object EvalRelationalExpression(ParseTree tree, params object[] paramlist)
        {
            object result = this.GetValue(tree, TokenType.ConcatEpression, 0);
            for (int i = 1; i < nodes.Count; i += 2)
            {
                Token token = nodes[i].Token;
                object val = nodes[i + 1].Eval(tree, paramlist);

                // compare as numbers
                if (result is double && val is double)
                {
                    if (token.Type == TokenType.LESSTHAN)
                        result = Convert.ToDouble(result) < Convert.ToDouble(val);
                    else if (token.Type == TokenType.LESSEQUAL)
                        result = Convert.ToDouble(result) <= Convert.ToDouble(val);
                    else if (token.Type == TokenType.GREATERTHAN)
                        result = Convert.ToDouble(result) > Convert.ToDouble(val);
                    else if (token.Type == TokenType.GREATEREQUAL)
                        result = Convert.ToDouble(result) >= Convert.ToDouble(val);
                }
                else // compare as strings
                {
                    int comp = string.Compare(Convert.ToString(result), Convert.ToString(val));
                    if (token.Type == TokenType.LESSTHAN)
                        result = comp < 0;
                    else if (token.Type == TokenType.LESSEQUAL)
                        result = comp <= 0;
                    else if (token.Type == TokenType.GREATERTHAN)
                        result = comp > 0;
                    else if (token.Type == TokenType.GREATEREQUAL)
                        result = comp >= 0;
                }

            }
            return result;
        }

        protected override object EvalEqualityExpression(ParseTree tree, params object[] paramlist)
        {
            object result = this.GetValue(tree, TokenType.RelationalExpression, 0);
            for (int i = 1; i < nodes.Count; i += 2)
            {
                Token token = nodes[i].Token;
                object val = nodes[i + 1].Eval(tree, paramlist);
                if (token.Type == TokenType.EQUAL)
                    result = object.Equals(result, val);
                else if (token.Type == TokenType.NOTEQUAL)
                    result = !object.Equals(result, val);
            }
            return result;
        }

        protected override object EvalConditionalAndExpression(ParseTree tree, params object[] paramlist)
        {
            object result = this.GetValue(tree, TokenType.EqualityExpression, 0);
            for (int i = 1; i < nodes.Count; i += 2)
            {
                Token token = nodes[i].Token;
                object val = nodes[i + 1].Eval(tree, paramlist);
                if (token.Type == TokenType.AMPAMP)
                    result = Convert.ToBoolean(result) && Convert.ToBoolean(val);
            }
            return result;
        }

        protected override object EvalConditionalOrExpression(ParseTree tree, params object[] paramlist)
        {
            object result = this.GetValue(tree, TokenType.ConditionalAndExpression, 0);
            for (int i = 1; i < nodes.Count; i += 2)
            {
                Token token = nodes[i].Token;
                object val = nodes[i + 1].Eval(tree, paramlist);
                if (token.Type == TokenType.PIPEPIPE)
                    result = Convert.ToBoolean(result) || Convert.ToBoolean(val);
            }
            return result;
        }

        protected override object EvalAssignmentExpression(ParseTree tree, params object[] paramlist)
        {
            object result = this.GetValue(tree, TokenType.ConditionalOrExpression, 0);
            if (nodes.Count >= 5 && result is bool
                && nodes[1].Token.Type == TokenType.QUESTIONMARK
                && nodes[3].Token.Type == TokenType.COLON)
            {
                if (Convert.ToBoolean(result))
                    result = nodes[2].Eval(tree, paramlist); // return 1st argument
                else
                    result = nodes[4].Eval(tree, paramlist); // return 2nd argumen
            }
            return result;
        }

        protected override object EvalExpression(ParseTree tree, params object[] paramlist)
        {
            // if only left hand side available, this is not an assignment, simple evaluate expression
            if (nodes.Count == 1)
                return this.GetValue(tree, TokenType.AssignmentExpression, 0); // return the result

            if (nodes.Count != 3)
            {
                tree.Errors.Add(new ParseError("Illegal EvalExpression format", 1092, this));
                return null;
            }

            // ok, this is an assignment so declare the function or variable
            // assignment only allowed to function or to a variable
            ParseNode v = GetFunctionOrVariable(nodes[0]);
            if (v == null)
            {
                tree.Errors.Add(new ParseError("Can only assign to function or variable", 1020, this));
                return null;
            }

            ParseTreeEvaluator root = tree as ParseTreeEvaluator;
            if (root == null)
            {
                tree.Errors.Add(new ParseError("Invalid parser used", 1040, this));
                return null;
            }

            if (root.Context == null)
            {
                tree.Errors.Add(new ParseError("No context defined", 1041, this));
                return null;
            }

            if (v.Token.Type == TokenType.VARIABLE)
            {

                // simply overwrite any previous defnition
                string key = v.Token.Text;
                root.Context.Globals[key] = this.GetValue(tree, TokenType.AssignmentExpression, 1);
                return null;
            }
            else if (v.Token.Type == TokenType.Function)
            {

                string key = v.Nodes[0].Token.Text.ToLower();

                // function lookup is case insensitive
                if (root.Context.Functions.ContainsKey(key))
                    if (!(root.Context.Functions[key] is DynamicFunction))
                    {
                        tree.Errors.Add(new ParseError("Built in functions cannot be overwritten", 1050, this));
                        return null;
                    }

               
                // check the function parameters to be of type Variable, error otherwise
                Variables vars = new Variables();
                ParseNode paramsNode = v.Nodes[2];
                if (paramsNode.Token.Type == TokenType.Params)
                {   // function has parameters, so check if they are all variable declarations
                    for (int i = 0; i < paramsNode.Nodes.Count; i += 2)
                    {
                        ParseNode varNode = GetFunctionOrVariable(paramsNode.Nodes[i]);
                        if (varNode == null || varNode.Token.Type != TokenType.VARIABLE)
                        {
                            tree.Errors.Add(new ParseError("Function declaration may only contain variables", 1051, this));
                            return null;
                        }
                        // simply declare the variable, no need to evaluate the value of it at this point. 
                        // evaluation will be done when the function is executed
                        // note, variables are Case Sensitive (!)
                        vars.Add(varNode.Token.Text, null);
                    }
                }
                // we have all the info we need to know to declare the dynamicly defined function
                // pass on nodes[2] which is the Right Hand Side (RHS) of the assignment
                // nodes[2] will be evaluated at runtime when the function is executed.
                DynamicFunction dynf = new DynamicFunction(key, nodes[2], vars, vars.Count, vars.Count);
                root.Context.Functions[key] = dynf;
                return null;
            }



            // in an assignment, dont return any result (basically void)
            return null;
        }

        // helper function to find access the function or variable
        private ParseNode GetFunctionOrVariable(ParseNode n)
        {
            // found the right node, exit
            if (n.Token.Type == TokenType.Function || n.Token.Type == TokenType.VARIABLE)
                return n;

            if (n.Nodes.Count == 1) // search lower branch (left side only, may not contain other node branches)
                return GetFunctionOrVariable(n.Nodes[0]);

            // function or variable not found in branch
            return null;
        }

        protected override object EvalLiteral(ParseTree tree, params object[] paramlist)
        {
            TokenType type = this.nodes[0].Token.Type;
            if (type == TokenType.StringLiteral)
                return this.GetValue(tree, TokenType.StringLiteral, 0);
            else if (type == TokenType.IntegerLiteral)
                return this.GetValue(tree, TokenType.IntegerLiteral, 0);
            else if (type == TokenType.RealLiteral)
                return this.GetValue(tree, TokenType.RealLiteral, 0);
            else if (type == TokenType.BOOLEANLITERAL)
            {
                string val = this.GetValue(tree, TokenType.BOOLEANLITERAL, 0).ToString();
                return Convert.ToBoolean(val);
            }
           
            tree.Errors.Add(new ParseError("illegal Literal format", 1003, this));
            return null;
        }

        protected override object EvalIntegerLiteral(ParseTree tree, params object[] paramlist)
        {
            if (this.GetValue(tree, TokenType.DECIMALINTEGERLITERAL, 0) != null)
                return Convert.ToDouble(this.GetValue(tree, TokenType.DECIMALINTEGERLITERAL, 0));
            if (this.GetValue(tree, TokenType.HEXINTEGERLITERAL, 0) != null)
            {
                string hex = this.GetValue(tree, TokenType.HEXINTEGERLITERAL, 0).ToString();
                return Convert.ToDouble(Convert.ToInt64(hex.Substring(2, hex.Length - 2), 16));
            }

            tree.Errors.Add(new ParseError("illegal IntegerLiteral format", 1002, this));
            return null;
        }

        protected override object EvalRealLiteral(ParseTree tree, params object[] paramlist)
        {
            if (this.GetValue(tree, TokenType.REALLITERAL, 0) != null)
            {
                string val = string.Format(CultureInfo.InvariantCulture, "{0}", this.GetValue(tree, TokenType.REALLITERAL, 0));
                return double.Parse(val, CultureInfo.InvariantCulture);
            }
            tree.Errors.Add(new ParseError("illegal RealLiteral format", 1001, this));
            return null;
        }

        protected override object EvalStringLiteral(ParseTree tree, params object[] paramlist)
        {
            if (this.GetValue(tree, TokenType.STRINGLITERAL, 0) != null)
            {
                string r = (string)this.GetValue(tree, TokenType.STRINGLITERAL, 0);
                r = r.Substring(1, r.Length - 2); // strip quotes
                return r;
            }

            tree.Errors.Add(new ParseError("illegal StringLiteral format", 1000, this));
            return string.Empty;
        }


    }

    #endregion ParseTree
}
