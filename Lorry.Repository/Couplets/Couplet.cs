using System;
using System.Collections.Generic;

namespace Lorry.Repository.Couplets
{
    public class Couplet
    {
        public int CoupletId { get; set; }
        public string CoupletContent { get; set; }
        public string CoupletRhyme { get; set; }
    }

    public static class CoupletMapperExtension
    {

        // Create AutoMapper configuration for mapping database model objects to repository model objects
        public static AutoMapper.MapperConfiguration mapperConfig = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Lorry.Database.Couplet, Lorry.Repository.Couplets.Couplet>().ReverseMap());
        public static AutoMapper.IMapper mapper = mapperConfig.CreateMapper();

        /// <summary>
        /// Converts TimecardRepository.Models.Couplet object to Database object Lorry.Database.Couplet for CRUD operations.
        /// </summary>
        /// <param name="databaseObject"></param>
        /// <returns></returns>
        public static Lorry.Database.Couplet ToDbModel(this Lorry.Repository.Couplets.Couplet repositoryObject)
        {
            return mapper.Map<Lorry.Database.Couplet>(repositoryObject);
        }

        /// <summary>
        /// Converts Lorry.Database.Couplet object to TimecardRepository.Models.Couplet object.
        /// </summary>
        /// <param name="databaseObject"></param>
        /// <returns></returns>
        public static Lorry.Repository.Couplets.Couplet ToRepositoryModel(this Lorry.Database.Couplet databaseObject)
        {
            return mapper.Map<Lorry.Repository.Couplets.Couplet>(databaseObject);
        }

    }


}
