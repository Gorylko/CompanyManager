namespace CompanyManager.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public class WorkAreaService : CommonService
    {
        public WorkArea GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id must be more than 0", nameof(id));
            }

            using (var uow = UnitOfWork)
            {
                WorkAreaDto workAreaDto;
                workAreaDto = uow.WorkAreaRepository.GetById(id) ?? throw new ArgumentNullException(nameof(workAreaDto));
                return workAreaDto?.ToWorkArea();
            }
        }

        public IEnumerable<WorkArea> GetAll()
        {
            using (var uow = UnitOfWork)
            {
                return uow.WorkAreaRepository.GetAll()?.Select(wa => wa.ToWorkArea());
            }
        }

        public WorkArea GetByEnterpriseId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id must be more than 0", nameof(id));
            }

            using (var uow = UnitOfWork)
            {
                WorkAreaDto workAreaDto;
                workAreaDto = uow.WorkAreaRepository.GetAll()
                                                    .FirstOrDefault(wa => wa.EnterpriseId == id) ?? throw new ArgumentNullException(nameof(workAreaDto));
                return workAreaDto?.ToWorkArea();
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id must be more than 0", nameof(id));
            }

            using (var uow = UnitOfWork)
            {
                WorkAreaDto workAreaDto;
                workAreaDto = uow.WorkAreaRepository.GetById(id) ?? throw new ArgumentNullException(nameof(workAreaDto));
                uow.WorkAreaRepository.Delete(workAreaDto);

                //need to use try-catch block
                uow.SaveChanges();
            }
        }

        public void Update(WorkArea workArea)
        {
            if (workArea == null)
            {
                throw new ArgumentNullException(nameof(workArea));
            }

            using (var uow = UnitOfWork)
            {
                WorkAreaDto workAreaDto = uow.WorkAreaRepository.GetById(workArea.Id) ?? throw new ArgumentNullException(nameof(workAreaDto));
                uow.WorkAreaRepository.Update(workAreaDto);

                //need to use try-catch block
                uow.SaveChanges();
            }
        }

        public void Save(WorkArea workArea)
        {
            if (workArea == null)
            {
                throw new ArgumentNullException(nameof(workArea));
            }

            using (var uow = UnitOfWork)
            {
                var workAreaDto = workArea.ToWorkAreaDto();
                uow.WorkAreaRepository.Add(workAreaDto);

                //need to use try-catch block
                uow.SaveChanges();
            }
        }
    }
}
