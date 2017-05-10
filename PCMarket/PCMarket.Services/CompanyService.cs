namespace PCMarket.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using Microsoft.Owin;
    using Data.DataModels;
    using Data.Interfaces;
    using Data.Repositories;
    using Managers;
    using Models.BindingModels;
    using Models.Entities;
    using Models.ViewModels;

    public class CompanyService : Service<ICompanyUnitOfWork>
    {
        public CompanyService(
            PcMarketContextFactory contextFactory,
            ICompanyUnitOfWork unitOfWork,
            IOwinContext context) : base(contextFactory, unitOfWork, context)
        {
        }

        public CompanyService(PcMarketContextFactory contextFactory, IOwinContext context) : this(
            contextFactory,
            new CompanyUnitOfWork(
                contextFactory.DataWorker,
                new CompanyRepository(contextFactory)),
            context)
        {
        }

        public IEnumerable<CompanyViewModel> GetAllCompanies()
        {
            return this.UnitOfWork
                .Companies
                .FindAll()
                .Select(c => new CompanyViewModel
                {
                    CompanyName = c.CompanyName,
                    Description = c.Description,
                    EstablishOn = c.EstablishOn,
                    LogoImageUrl = c.LogoImageUrl
                });
        }

        public void AddCompany(CompanyBindingModel company, TemproaryFileManager fileManager)
        {
            var webClient = new WebClient();
            var uri = webClient.DownloadData(new Uri(company.LogoImageUrl));
            if (!fileManager.ChechIfFolderExists($"{fileManager.BaseDirectoryContainer}\\Company"))
            {
                fileManager.CreateFolder($"{fileManager.BaseDirectoryContainer}\\Company");
            }

            var sourcepath = $"{fileManager.BaseDirectoryContainer}\\Company\\{fileManager.GetFilename(company.LogoImageUrl)}";
            fileManager.UploadFile(uri, sourcepath);
            this.UnitOfWork.Companies.Create(new Company
            {
                CompanyName = company.CompanyName,
                Description = company.Description,
                EstablishOn = company.EstablishOn,
                LogoImageUrl = sourcepath
            });
            this.UnitOfWork.SaveChanges();
        }

        public void EditCompany(CompanyBindingModel company)
        {
            var companyEntity = this.UnitOfWork
                .Companies
                .Find(
                    new Expression<Func<Company, bool>>[]
                    {
                        c => c.CompanyName == company.CompanyName
                    });
            companyEntity.CompanyName = company.CompanyName;
            companyEntity.Description = company.Description;
            companyEntity.EstablishOn = company.EstablishOn;
            companyEntity.LogoImageUrl = company.LogoImageUrl;
            this.UnitOfWork.Companies.Update(companyEntity);
            this.UnitOfWork.SaveChanges();
        }
    }
}