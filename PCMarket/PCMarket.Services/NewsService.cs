namespace PCMarket.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.Owin;
    using Data.DataModels;
    using Data.Interfaces;
    using Data.Repositories;
    using Models.BindingModels.News;
    using Models.Entities.News;
    using Models.Entities.Users;
    using Models.ViewModels.News;

    public class NewsService : Service<INewsUnitOfWork>
    {
        public NewsService(
            PcMarketContextFactory contextFactory,
            INewsUnitOfWork unitOfWork,
            IOwinContext context) : base(contextFactory, unitOfWork, context)
        {
        }

        public NewsService(PcMarketContextFactory contextFactory, IOwinContext context) : this(
            contextFactory,
            new NewsUnitOfWork(
                contextFactory.DataWorker,
                new SoftwareNewRepository(contextFactory),
                new HardwareNewRepository(contextFactory)),
            context)
        {
        }

        public void AddSoftwareNew(SoftwareNewBindingModel softwareNewBindingModel, AdminUser user)
        {
            this.UnitOfWork.SoftwareNews.Create(new SoftwareNew
            {
                Title = softwareNewBindingModel.Title,
                Subject = softwareNewBindingModel.Subject,
                Body = softwareNewBindingModel.Body,
                Author = user
            });
            this.UnitOfWork.SaveChanges();
        }

        public SoftwareNewViewModel GetSoftwareNewById(int id)
        {
            var @new = this.UnitOfWork
                .SoftwareNews
                .Find(new Expression<Func<SoftwareNew, bool>>[] { sn => sn.Id == id });
            return @new != null ? new SoftwareNewViewModel
            {
                Id = @new.Id,
                Title = @new.Title,
                Body = @new.Body,
                Subject = @new.Subject
            } : new SoftwareNewViewModel
            {
                Id = 0,
                Title = "",
                Body = "",
                Subject = ""
            };
        }

        public IEnumerable<SoftwareNewViewModel> GetSoftwareNews(int? count)
        {
            var hasCount = count != null;
            return !hasCount ? this.UnitOfWork.SoftwareNews
                .FindAll()
                .Select(n => new SoftwareNewViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Body = n.Body,
                    Subject = n.Subject
                })
                .OrderByDescending(s => s.Title)
                .ThenByDescending(s => s.Subject) :
            this.UnitOfWork.SoftwareNews
                .FindAll()
                .Select(n => new SoftwareNewViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Body = n.Body,
                    Subject = n.Subject
                })
                .OrderByDescending(s => s.Subject)
                .ThenByDescending(s => s.Subject)
                .Take(count.Value);
        }

        public SoftwareNewViewModel GetShortVersion(SoftwareNewViewModel viewModel)
        {
            return new SoftwareNewViewModel
            {
                Title = $"{string.Join(string.Empty, viewModel.Title.Take(10))} ...",
                Subject = $"{string.Join(string.Empty, viewModel.Subject.Take(8))} ...",
                Body = $"{string.Join(string.Empty, viewModel.Body.Take(20))} ..."
            };
        }

        public IEnumerable<HardwareNewViewModel> GetHardwareNews(int? count)
        {
            var hasCount = count != null;
            var entities = this.UnitOfWork.HardwareNews
                .FindAll();
            return !hasCount ?
                entities.Select(e => new HardwareNewViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Subject = e.Subject,
                    Body = e.Body
                }) :
                entities.Select(e => new HardwareNewViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Subject = e.Subject,
                    Body = e.Body
                }).Take(count.Value);
        }

        public HardwareNewViewModel GetHardwareNewById(int id)
        {
            var @new = this.UnitOfWork.HardwareNews
                .Find(new Expression<Func<HardwareNew, bool>>[] { hn => hn.Id == id });
            return @new == null
                ? new HardwareNewViewModel
                {
                    Id = 0,
                    Title = string.Empty,
                    Subject = string.Empty,
                    Body = string.Empty
                } :
                new HardwareNewViewModel
                {
                    Id = @new.Id,
                    Title = @new.Title,
                    Subject = @new.Subject,
                    Body = @new.Body
                };
        }

        public void AddHardwareNew(HardwareNewBindingModel bindingModel, AdminUser author)
        {
            this.UnitOfWork.HardwareNews.Create(new HardwareNew
            {
                Title = bindingModel.Title,
                Subject = bindingModel.Subject,
                Body = bindingModel.Body,
                Author = author
            });
            this.UnitOfWork.SaveChanges();
        }

        public SoftwareNewBindingModel GetEditForSoftwareNew(int id)
        {
            var @new = this.UnitOfWork.SoftwareNews.Find(new Expression<Func<SoftwareNew, bool>>[] { s => s.Id == id });
            return new SoftwareNewBindingModel
            {
                Id = @new.Id,
                Body = @new.Body,
                Title = @new.Title,
                Subject = @new.Subject
            };
        }

        public void EditSoftwareNew(SoftwareNewBindingModel bindingModel)
        {
            var @new = this.UnitOfWork
                .SoftwareNews
                .Find(
                    new Expression<Func<SoftwareNew, bool>>[]
                        {
                            sn => sn.Id == bindingModel.Id
                        });
            @new.Body = bindingModel.Body;
            @new.Title = bindingModel.Title;
            @new.Subject = bindingModel.Subject;
            this.UnitOfWork.SoftwareNews.Update(@new);
            this.UnitOfWork.SaveChanges();
        }

        public HardwareNewBindingModel GetEditForHardwareNew(int id)
        {
            var @new = this.UnitOfWork.HardwareNews.Find(new Expression<Func<HardwareNew, bool>>[] { s => s.Id == id });
            return new HardwareNewBindingModel
            {
                Id = @new.Id,
                Body = @new.Body,
                Title = @new.Title,
                Subject = @new.Subject
            };
        }

        public void EditHardwareNew(HardwareNewBindingModel bindingModel)
        {
            var @new = this.UnitOfWork
                .HardwareNews
                .Find(
                    new Expression<Func<HardwareNew, bool>>[]
                        {
                            s => s.Id == bindingModel.Id
                        });
            @new.Body = bindingModel.Body;
            @new.Title = bindingModel.Title;
            @new.Subject = bindingModel.Subject;
            this.UnitOfWork.HardwareNews.Update(@new);
            this.UnitOfWork.SaveChanges();
        }

        public void DeleteSoftwareNew(int id)
        {
            var @new = this.UnitOfWork.SoftwareNews.Find(new Expression<Func<SoftwareNew, bool>>[] { hn => hn.Id == id });
            this.UnitOfWork.SoftwareNews.Delete(@new);
            this.UnitOfWork.SaveChanges();
        }

        public void DeleteHardwareNew(int id)
        {
            var @new = this.UnitOfWork.HardwareNews.Find(new Expression<Func<HardwareNew, bool>>[] { hn => hn.Id == id });
            this.UnitOfWork.HardwareNews.Delete(@new);
            this.UnitOfWork.SaveChanges();
        }
    }
}