#region NameSpace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Web;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Models;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles;
using System.Text.RegularExpressions;
using System.Data;
using System.Transactions;
using System.Net.Http;
using System.Net.Http.Headers;
#endregion


namespace UraxUIServiceWebApi.Models
{
    public class Pno12Data
    {
        public int Pno12Id { get; set; }
        public string Pno12String { get; set; }
        public string ModelYear { get; set; }
        public string CarLine { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> MarketId { get; set; }

        public List<Pno12AllData> GetPno12AllData()
        {
            try
            {
                using (var Pno12Repo = new UnitofWork())
                {
                    var lstPno12 = (from pno in Pno12Repo.Pno12Repository.GetAll()
                                    join pfp in Pno12Repo.Pno12FixedParametersRepository.GetAll() on pno.Pno12Id equals pfp.Pno12Id
                                    join pd in Pno12Repo.Pno12ParameterDefinitionRepository.GetAll() on pfp.Pno12PdId equals pd.Pno12PdId
                                    join pt in Pno12Repo.Pno12ParameterTypeRepository.GetAll() on pd.Pno12PtId equals pt.Pno12PtId
                                    select new { pfp.Pno12Id,pfp.Pno12PdId,pfp.ParameterValue,pd.DefinitionName,pd.ShortName,pd.DataType,pd.Pno12PtId,pd.Pno12UomId,pd.Description,
                                    pno.ModelYear,pno.MarketId,pno.Pno121,pno.CarLine,pt.ParameterTypeName,pt.ParameterTypeDescription}).ToList();
                    var FinalLstPno12 = (from pn in lstPno12
                                         join uom in Pno12Repo.Pno12UnitOfMeasurementRepository.GetAll()

                                         on pn.Pno12UomId equals uom.Pno12UomId into dep
                                         from puom in dep.DefaultIfEmpty()
                                         select new { pn , puom }).ToList();
                    List<Pno12AllData> result = new List<Pno12AllData>();
                    string Name = string.Empty;
                    string LongName = string.Empty;
                    int Pno12UomId = 0;
                    foreach (var item in FinalLstPno12)
                    {
                        if (item.puom!=null)
                        {
                            Name =item.puom.Name;
                           LongName = item.puom.LongName;
                          Pno12UomId =item.puom.Pno12UomId;
                        }
                       
                        result.Add(new Pno12AllData()
                        {
                            Pno12String = item.pn.Pno121,
                            ModelYear = item.pn.ModelYear,
                            CarLine = item.pn.CarLine,
                            MarketId = item.pn.MarketId,
                            ParameterTypeName = item.pn.ParameterTypeName,
                            ParameterTypeDescription = item.pn.ParameterTypeDescription,
                            Pno12Id = item.pn.Pno12Id,
                            Pno12PdId = item.pn.Pno12PdId,
                            ParameterValue = item.pn.ParameterValue,
                            DefinitionName = item.pn.DefinitionName,
                            ShortName = item.pn.ShortName,
                            DataType = item.pn.DataType,
                            Pno12PtId = item.pn.Pno12PtId,
                            Pno12UomId = Pno12UomId,
                            Name = Name ,
                            LongName = LongName

                        });
                    }
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ParameterList> GetAllPno12Parameters()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (var pno12Repo = new UnitofWork())
                    {
                        List<ParameterList> lstParameter = new List<ParameterList>();
                        var lstPno12 = pno12Repo.Pno12Repository.GetAll();
                        var lstPno12ParameterDefinition = pno12Repo.Pno12ParameterDefinitionRepository.GetAll();
                        //Pno12DataModel Pno12Model = new Pno12DataModel();
                       // List<Pno12DataModel> result = new List<Pno12DataModel>();

                        foreach (var item in lstPno12)
                        {
                            lstParameter.Add(new ParameterList()
                            {
                                Pno12Id=item.Pno12Id,
                                ParameterValue=item.MarketId.ToString(),
                                ParameterName="Market Code"
                            });
                            lstParameter.Add(new ParameterList()
                            {
                                Pno12Id = item.Pno12Id,
                                ParameterValue = item.ModelYear.ToString(),
                                ParameterName = "ModelYear"
                            });
                            lstParameter.Add(new ParameterList()
                            {
                                Pno12Id = item.Pno12Id,
                                ParameterValue = item.CarLine.ToString(),
                                ParameterName = "CarLine"
                            });
                            lstParameter.Add(new ParameterList()
                            {
                                Pno12Id = item.Pno12Id,
                                ParameterValue = item.Pno121.ToString(),
                                ParameterName = "Pno12"
                            });
                            var lstFixedParameters = pno12Repo.Pno12FixedParametersRepository.Find(x => x.Pno12Id == item.Pno12Id).ToList();
                            //List<string> ParameterName = lstPno12ParameterDefinition.Select(x => x.DefinitionName).ToList();
                            //List<string> ParameterValue = lstFixedParameters.Select(x => x.ParameterValue).ToList();
                            //var ParameterData = ParameterName.Join(ParameterValue, s => ParameterName.IndexOf(s), i => ParameterValue.IndexOf(i), (s, i) => new { Value = i, Name = s }).ToList();
                                foreach (var data in lstPno12ParameterDefinition)

                                {
                                foreach (var param in lstFixedParameters)

                                {
                                   
                                     if ( param.Pno12PdId==data.Pno12PdId)
                                    {
                                        lstParameter.Add(new ParameterList()
                                        {
                                            Pno12Id = item.Pno12Id,
                                            Pno12PdId=data.Pno12PdId,
                                            ParameterValue = param.ParameterValue,
                                            ParameterName = data.DefinitionName
                                        });
                                    }
                                    
                                }
                                if (pno12Repo.Pno12FixedParametersRepository.Find(x => x.Pno12Id == item.Pno12Id && x.Pno12PdId == data.Pno12PdId).ToList().Count == 0)
                                {
                                    lstParameter.Add(new ParameterList()
                                    {
                                        Pno12Id = item.Pno12Id,
                                        Pno12PdId = data.Pno12PdId,
                                        ParameterValue = null,
                                        ParameterName = data.DefinitionName
                                    });
                                }
                            }
                            
                            //result.Add(new Pno12DataModel()
                            //{
                            //    ParameterList = lstParameter
                            //});
                        }
                        return lstParameter;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAllData()
        {
            try
            {
               
                    using (var pno12Repo = new  UnitofWork())
                    {
                        List<PnoData> ListPno = new List<PnoData>();

                    var pno12Data = pno12Repo.Pno12Repository.GetAll();

                    foreach (var pno in pno12Data)
                    {
                        Pno12FixedParameter parameterMarketCode = new Pno12FixedParameter()
                        {
                            Pno12Id = pno.Pno12Id,
                            Pno12PdId = -4,
                            ParameterValue = pno.MarketId.ToString()

                        };
                        Pno12FixedParameter parameterPno12 = new Pno12FixedParameter()
                        {
                            Pno12Id = pno.Pno12Id,
                            Pno12PdId = -3,
                            ParameterValue = pno.Pno121

                        };
                        Pno12FixedParameter parameterModelYear = new Pno12FixedParameter()
                        {
                            Pno12Id = pno.Pno12Id,
                            Pno12PdId = -2,
                            ParameterValue = pno.ModelYear

                        }; Pno12FixedParameter parameterCarLine = new Pno12FixedParameter()
                        {
                            Pno12Id = pno.Pno12Id,
                            Pno12PdId = -1,
                            ParameterValue = pno.CarLine

                        };
                        List<Pno12FixedParameter> pnofpList = new List<Pno12FixedParameter>() { parameterPno12, parameterModelYear, parameterCarLine, parameterMarketCode };
                        foreach (var fp in pnofpList)
                        {
                            string DefName = string.Empty;
                            switch (fp.Pno12PdId)
                            {
                                case -1:
                                    DefName = "CarLine";
                                    break;
                                case -2:
                                    DefName = "ModelYear";
                                    break;
                                case -3:
                                    DefName = "Pno12";
                                    break;
                                case -4:
                                    DefName = "MarketCode";
                                    break;
                            }
                            ListPno.Add(new PnoData
                            {
                                FixedParameter = fp,
                                Definition = DefName
                            });
                        }

                    }

                    var pnoJoinFixedData = (from pfp in pno12Repo.Pno12FixedParametersRepository.GetAll()
                                           join ppd in pno12Repo.Pno12ParameterDefinitionRepository.GetAll() 
                                            on pfp.Pno12PdId equals ppd.Pno12PdId
                                           select new  {
                                               FixedParameter =pfp,Definition=ppd.DefinitionName}).ToList();
                        foreach (var item in pnoJoinFixedData)
                        {
                            Pno12FixedParameter parameterdata = new Pno12FixedParameter() {
                                Pno12Id=item.FixedParameter.Pno12Id,
                                Pno12PdId= item.FixedParameter.Pno12PdId,
                                ParameterValue= item.FixedParameter.ParameterValue
                                
                            };
                            ListPno.Add(new PnoData
                            {
                                FixedParameter=parameterdata,
                                Definition= item.Definition
                                 //  Definition = item.Definition.Replace(" ", "")
                            });
                        }
                        var result = GetAllPno12PivotData(ListPno);
                      
                        result.PrimaryKey = new DataColumn[] { result.Columns["Pno12Id"] };

                       


                        return result;
                    }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<PnoHeaderList> GetHeader()
        {
            try
            {
                List<string> variableList;
                //using (EF.URAXEntities context = new EF.URAXEntities())
                //{

                //    string CommandText = @"SELECT column_name FROM information_schema.columns WHERE table_name = 'Pno12'" ;
                //     variableList = context.Database.SqlQuery<string>(CommandText).ToList();
                //}
                    using (var pno12Repo = new UnitofWork())
                {
                    List<PnoHeaderList> HeaderList = new List<PnoHeaderList>();
                    List<string> ParametersList = new List<string>(Helper.sPnoParameters.Split(','));
                    foreach (var item in ParametersList)
                    {
                        
                            HeaderList.Add(new PnoHeaderList
                            {
                                Field = item,
                                Header = item
                            }); 
                        
                    }

                    var pnoJoinFixedData = (from pfp in pno12Repo.Pno12FixedParametersRepository.GetAll()
                                            join ppd in pno12Repo.Pno12ParameterDefinitionRepository.GetAll()
                                             on pfp.Pno12PdId equals ppd.Pno12PdId
                                            select   ppd.DefinitionName).Distinct().ToList();
                    foreach (var item in pnoJoinFixedData)
                    {
                        HeaderList.Add(new PnoHeaderList
                        {
                            Field = item,
                            Header = item
                        });
                    }
                    return HeaderList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAllPnoParameters()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (var Pno12Repo = new UnitofWork())
                    {
                        var lstPno12 = (from pno in Pno12Repo.Pno12Repository.GetAll()
                                        join pfp in Pno12Repo.Pno12FixedParametersRepository.GetAll() on pno.Pno12Id equals pfp.Pno12Id
                                        join pd in Pno12Repo.Pno12ParameterDefinitionRepository.GetAll() on pfp.Pno12PdId equals pd.Pno12PdId
                                        join pt in Pno12Repo.Pno12ParameterTypeRepository.GetAll() on pd.Pno12PtId equals pt.Pno12PtId
                                        select new
                                        {
                                            pfp.Pno12Id,
                                            pfp.Pno12PdId,
                                            pfp.ParameterValue,
                                            pd.DefinitionName,
                                            pd.ShortName,
                                            pd.DataType,
                                            pd.Pno12PtId,
                                            pd.Pno12UomId,
                                            pd.Description,
                                            pno.ModelYear,
                                            pno.MarketId,
                                            pno.Pno121,
                                            pno.CarLine,
                                            pt.ParameterTypeName,
                                            pt.ParameterTypeDescription
                                        }).ToList();
                        var FinalLstPno12 = (from pn in lstPno12
                                             join uom in Pno12Repo.Pno12UnitOfMeasurementRepository.GetAll()

                                             on pn.Pno12UomId equals uom.Pno12UomId into dep
                                             from puom in dep.DefaultIfEmpty()
                                             select new { pn, puom }).ToList();
                        List<DynamicPno12List> lst = new List<DynamicPno12List>();

                        foreach (var item in FinalLstPno12)
                        {
                            lst.Add(new DynamicPno12List()
                            {
                                Pno12Id= item.pn.Pno12Id,
                                Pno12PdId=item.pn.Pno12PdId,
                                DefinitionName=item.pn.DefinitionName,
                                ParameterValue=item.pn.ParameterValue
                            });
                        }

                        var result = GetPno12PivotData(lst);
                        return result;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetPno12PivotData(List<DynamicPno12List> dynamicData)
        {

            List<DynamicPno12List> lst = new List<DynamicPno12List>();
            foreach (var item in dynamicData)
            {
                lst.Add(new DynamicPno12List()
                {
                    DefinitionName = item.DefinitionName,
                    Pno12Id = item.Pno12Id,
                    ParameterValue = item.ParameterValue,
                    Pno12PdId = item.Pno12PdId
                    

                }
                );
            }


            var pivotTable = lst.ToPivotTable(
                          item => item.DefinitionName,
                          item => item.Pno12Id,

                          items => items.Sum(x => x.Pno12PdId&x.Pno12Id));

            int row = pivotTable.Rows.Count;
            int i = 0;
            var countcol = lst.Select(x => x.DefinitionName).Distinct().Count();
            for (int x = 0; x < row; x++)
            {
                for (int y = 1; y <= countcol; y++)
                {
                    pivotTable.Rows[x][y] = lst[i].ParameterValue;
                    i++;
                }

            }
            return pivotTable;
        }

        public DataTable GetAllPno12PivotData(List<PnoData> dynamicData)
        {

            List<DynamicPno12List> lst = new List<DynamicPno12List>();
           dynamicData= dynamicData.OrderBy(x => x.FixedParameter.Pno12Id).ThenBy(x => x.FixedParameter.Pno12PdId).ToList();
            foreach (var item in dynamicData)
            {
                lst.Add(new DynamicPno12List()
                {
                    DefinitionName = item.Definition,
                    Pno12Id = item.FixedParameter.Pno12Id,
                    ParameterValue = item.FixedParameter.ParameterValue,
                    Pno12PdId = item.FixedParameter.Pno12PdId


                }
                );
            }


            var pivotTable = lst.ToPivotTable(
                          item => item.DefinitionName,
                          item => item.Pno12Id,

                          items => items.Sum(x => x.Pno12PdId ));

            int row = pivotTable.Rows.Count;
            int i = 0;
            var countcol = lst.Select(x => x.DefinitionName).Distinct().Count();
            for (int x = 0; x < row; x++)
            {
                for (int y = 1; y <= countcol; y++)
                {
                    if (Convert.ToInt32(pivotTable.Rows[x][y]) != 0)
                    {
                        var pno12Id = Convert.ToInt64(pivotTable.Rows[x][0]);
                        var pno12PdId = Convert.ToInt64(pivotTable.Rows[x][y]);
                        var value = lst.Find(z => z.Pno12Id == pno12Id && z.Pno12PdId == pno12PdId).ParameterValue;
                        pivotTable.Rows[x][y] = value;
                        i++;
                    }
                }

            }
                return pivotTable;
        }
    }
   
    public class Pno12DataModel
    {
        public List<ParameterList> ParameterList { get; set; }
    }
    public class PnoData
    {
        public Pno12FixedParameter FixedParameter { get; set; }
        public string Definition { get; set; }
    }
    public class ParameterList
    {
        public long Pno12Id { get; set; }
        public long Pno12PdId { get; set; }
        public string ParameterName { get; set; }
        public string  ParameterValue { get; set; }
    }

    public class DynamicPno12List
    {
        public string DefinitionName { get; set; }
        public long Pno12PdId { get; set; }
        public string  ParameterValue { get; set; }
        public long  Pno12Id { get; set; }
     
    }
    public class Pno12AllData
    {
        public string Pno12String { get; set; }
        public string ModelYear { get; set; }
        public string CarLine { get; set; }
        public long? MarketId { get; set; }
        public string ParameterTypeName { get; set; }
        public string ParameterTypeDescription { get; set; }
        public int? Pno12Id { get; set; }
        public int? Pno12PdId { get; set; }
        public string ParameterValue { get; set; }
        public string DefinitionName { get; set; }
        public string ShortName { get; set; }
        public string DataType { get; set; }
        public int? Pno12PtId { get; set; }
        public int? Pno12UomId { get; set; }
        public string Name { get; set; }
        public string LongName { get; set; }
    }

    public class PnoHeaderList
    {
        public string Field { get; set; }
        public string Header { get; set; }
    }
   

}