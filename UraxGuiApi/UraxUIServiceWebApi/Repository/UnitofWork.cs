using System;
using System.Data.Entity;

namespace UraxUIServiceWebApi.Repository
{
    public class UnitofWork : IDisposable
    {
      readonly  private DbContext context;

        public UnitofWork()
        {
         
                context = new EF.URAXEntities();
        }
        private Repository<EF.CurrencyDetail> currencyDetailsRepository;
        private Repository<EF.CountryCode> countryCodeRepository;
        private Repository<EF.PnoGroupMaster> pnoGroupRepository;
        private Repository<EF.PnoNumber> pnoNumberRepository;
        private Repository<EF.PnoParameter> pnoParameterRepository;
        private Repository<EF.PnoVariableMaster> pnoVariableRepository;
        private Repository<EF.Market> marketRepository;
        private Repository<EF.TaxMaster> taxmasterRepository;
        private Repository<EF.TaxVersion> taxVersionRepository;
        private Repository<EF.Tax> taxRepository;
        private Repository<EF.Variable> variableRepository;
        private Repository<EF.Formula> formulaRepository;
        private Repository<EF.FormulaDefinitionDependencyDetail> formulaDefinitionDependencyDetailsRepository;
        private Repository<EF.LookUpGroup> lookUpGroupRepository;
        private Repository<EF.LookupGroupDetail> lookupGroupDetailRepository;
        private Repository<EF.LookUpDetail> lookUpDetailsRepository;
        private Repository<EF.ParameterDetail> parameterDetailsRepository;
        private Repository<EF.LanguageDetail> languageDetailsRepository;
        private Repository<EF.Language> languagesRepository;
        private Repository<EF.MaterialNew> materialNewsRepository;
        private Repository<EF.UserDetail> userDetailRepository;
        private Repository<EF.UserRole> userRoleRepository;
        private Repository<EF.ParameterGroupMaster> parameterGroupMasterRepository;
        private Repository<EF.SubdivisionCode> subdivisionCodeRepository;
        private Repository<EF.Pno12> pno12Repository;
        private Repository<EF.Pno12FixedParameters> pno12FixedParametersRepository;
        private Repository<EF.Pno12ParameterDefinition> pno12ParameterDefinitionRepository;
        private Repository<EF.Pno12ParameterType> pno12ParameterTypeRepository;
        private Repository<EF.Pno12UnitOfMeasurement> pno12UnitOfMeasurementRepository;

        public Repository<EF.Pno12UnitOfMeasurement> Pno12UnitOfMeasurementRepository
        {
            get
            {
                if (this.pno12UnitOfMeasurementRepository == null)
                {
                    this.pno12UnitOfMeasurementRepository = new Repository<EF.Pno12UnitOfMeasurement>(context);
                }
                return pno12UnitOfMeasurementRepository;
            }
        }
        public Repository<EF.Pno12ParameterType> Pno12ParameterTypeRepository
        {
            get
            {
                if (this.pno12ParameterTypeRepository == null)
                {
                    this.pno12ParameterTypeRepository = new Repository<EF.Pno12ParameterType>(context);
                }
                return pno12ParameterTypeRepository;
            }
        }
        public Repository<EF.Pno12ParameterDefinition> Pno12ParameterDefinitionRepository
        {
            get
            {
                if (this.pno12ParameterDefinitionRepository == null)
                {
                    this.pno12ParameterDefinitionRepository = new Repository<EF.Pno12ParameterDefinition>(context);
                }
                return pno12ParameterDefinitionRepository;
            }
        }
        public Repository<EF.Pno12FixedParameters> Pno12FixedParametersRepository
        {
            get
            {
                if (this.pno12FixedParametersRepository == null)
                {
                    this.pno12FixedParametersRepository = new Repository<EF.Pno12FixedParameters>(context);
                }
                return pno12FixedParametersRepository;
            }
        }
        public Repository<EF.Pno12> Pno12Repository
        {
            get
            {
                if (this.pno12Repository == null)
                {
                    this.pno12Repository = new Repository<EF.Pno12>(context);
                }
                return pno12Repository;
            }
        }
        public Repository<EF.SubdivisionCode> SubdivisionCodeRepository
        {
            get
            {
                if (this.subdivisionCodeRepository == null)
                {
                    this.subdivisionCodeRepository = new Repository<EF.SubdivisionCode>(context);
                }
                return subdivisionCodeRepository;
            }
        }
        public Repository<EF.ParameterGroupMaster> ParameterGroupMasterRepository
        {
            get
            {
                if (this.parameterGroupMasterRepository == null)
                {
                    this.parameterGroupMasterRepository = new Repository<EF.ParameterGroupMaster>(context);
                }
                return parameterGroupMasterRepository;
            }
        }
        public Repository<EF.UserRole> UserRoleRepository
        {
            get
            {
                if (this.userRoleRepository == null)
                {
                    this.userRoleRepository = new Repository<EF.UserRole>(context);
                }
                return userRoleRepository;
            }
        }
        public Repository<EF.UserDetail> UserDetailRepository
        {
            get
            {
                if (this.userDetailRepository == null)
                {
                    this.userDetailRepository = new Repository<EF.UserDetail>(context);
                }
                return userDetailRepository;
            }
        }

        public Repository<EF.MaterialNew> MaterialNewsRepository
        {
            get
            {
                if (this.materialNewsRepository == null)
                {
                    this.materialNewsRepository = new Repository<EF.MaterialNew>(context);
                }
                return materialNewsRepository;
            }
        }

        public Repository<EF.Language> LanguagesRepository
        {
            get
            {
                if (this.languagesRepository == null)
                {
                    this.languagesRepository = new Repository<EF.Language>(context);
                }
                return languagesRepository;
            }
        }
        public Repository<EF.LanguageDetail> LanguageDetailsRepository
        {
            get
            {
                if (this.languageDetailsRepository == null)
                {
                    this.languageDetailsRepository = new Repository<EF.LanguageDetail>(context);
                }
                return languageDetailsRepository;
            }
        }
        public Repository<EF.ParameterDetail> ParameterDetailsRepository
        {
            get
            {
                if (this.parameterDetailsRepository == null)
                {
                    this.parameterDetailsRepository = new Repository<EF.ParameterDetail>(context);
                }
                return parameterDetailsRepository;
            }
        }
        public Repository<EF.CurrencyDetail> CurrencyDetailsRepository
        {
            get
            {
                if (this.currencyDetailsRepository == null)
                {
                    this.currencyDetailsRepository = new Repository<EF.CurrencyDetail>(context);
                }
                return currencyDetailsRepository;
            }
        }
        public Repository<EF.CountryCode> CountryCodeRepository
        {
            get
            {
                if (this.countryCodeRepository == null)
                {
                    this.countryCodeRepository = new Repository<EF.CountryCode>(context);
                }
                return countryCodeRepository;
            }
        }
        public Repository<EF.LookUpDetail> LookUpDetailsRepository
        {
            get
            {
                if (this.lookUpDetailsRepository == null)
                {
                    this.lookUpDetailsRepository = new Repository<EF.LookUpDetail>(context);
                }
                return lookUpDetailsRepository;
            }
        }
        public Repository<EF.LookupGroupDetail> LookupGroupDetailRepository
        {
            get
            {
                if (this.lookupGroupDetailRepository == null)
                {
                    this.lookupGroupDetailRepository = new Repository<EF.LookupGroupDetail>(context);
                }
                return lookupGroupDetailRepository;
            }
        }
        public Repository<EF.LookUpGroup> LookUpGroupRepository
        {
            get
            {
                if (this.lookUpGroupRepository == null)
                {
                    this.lookUpGroupRepository = new Repository<EF.LookUpGroup>(context);
                }
                return lookUpGroupRepository;
            }
        }
        public Repository<EF.FormulaDefinitionDependencyDetail> FormulaDefinitionDependencyDetailsRepository
        {
            get
            {
                if (this.formulaDefinitionDependencyDetailsRepository == null)
                {
                    this.formulaDefinitionDependencyDetailsRepository = new Repository<EF.FormulaDefinitionDependencyDetail>(context);
                }
                return formulaDefinitionDependencyDetailsRepository;
            }
        }
        public Repository<EF.TaxVersion> TaxVersionRepository
        {
            get
            {
                if (this.taxVersionRepository == null)
                {
                    this.taxVersionRepository = new Repository<EF.TaxVersion>(context);
                }
                return taxVersionRepository;
            }
        }
       
        public Repository<EF.Formula> FormulaRepository
        {
            get
            {
                if (this.formulaRepository == null)
                {
                    this.formulaRepository = new Repository<EF.Formula>(context);
                }
                return formulaRepository;
            }
        }
        public Repository<EF.Variable> VariableRepository
        {
            get
            {
                if (this.variableRepository == null)
                {
                    this.variableRepository = new Repository<EF.Variable>(context);
                }
                return variableRepository;
            }
        }
        public Repository<EF.Tax> TaxRepository
        {
            get
            {
                if (this.taxRepository == null)
                {
                    this.taxRepository = new Repository<EF.Tax>(context);
                }
                return taxRepository;
            }
        }
        public Repository<EF.TaxMaster> TaxMasterRepository
        {
            get
            {
                if (this.taxmasterRepository == null)
                {
                    this.taxmasterRepository = new Repository<EF.TaxMaster>(context);
                }
                return taxmasterRepository;
            }
        }

        public Repository<EF.Market> MarketRepository
        {
            get
            {
                if (this.marketRepository == null)
                {
                    this.marketRepository = new Repository<EF.Market>(context);
                }
                return marketRepository;
            }
        }

        public Repository<EF.PnoGroupMaster> PnoGroupMasterRepository
        {
            get
            {
                if (this.pnoGroupRepository == null)
                {
                    this.pnoGroupRepository = new Repository<EF.PnoGroupMaster>(context);
                }
                return pnoGroupRepository;
            }
        }
        public Repository<EF.PnoNumber> PnoNumberRepository
        {
            get
            {
                if (this.pnoNumberRepository == null)
                {
                    this.pnoNumberRepository = new Repository<EF.PnoNumber>(context);
                }
                return pnoNumberRepository;
            }
        }
        public Repository<EF.PnoParameter> PnoParameterRepository
        {
            get
            {
                if (this.pnoParameterRepository == null)
                {
                    this.pnoParameterRepository = new Repository<EF.PnoParameter>(context);
                }
                return pnoParameterRepository;
            }
        }
        public Repository<EF.PnoVariableMaster> PnoVariableMasterRepository
        {
            get
            {
                if (this.pnoVariableRepository == null)
                {
                    this.pnoVariableRepository = new Repository<EF.PnoVariableMaster>(context);
                }
                return pnoVariableRepository;
            }
        }
    

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if ((!this.disposed)&&disposing)
            {
                  context.Dispose();
               
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    
}