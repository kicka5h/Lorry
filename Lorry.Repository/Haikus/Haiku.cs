using System;
using System.Collections.Generic;

namespace Lorry.Repository.Haikus
{
    public partial class Haiku
    {
        public int HaikuId { get; set; }
        public string HaikuContent { get; set; }
        public string HaikuCount { get; set; }
    }

    public static class HaikuMapperExtension
    {

        // Create AutoMapper configuration for mapping database model objects to repository model objects
        public static AutoMapper.MapperConfiguration mapperConfig = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Lorry.Database.Haiku, Lorry.Repository.Haikus.Haiku>().ReverseMap());
        public static AutoMapper.IMapper mapper = mapperConfig.CreateMapper();

        /// <summary>
        /// Converts TimecardRepository.Models.Couplet object to Database object Lorry.Database.Couplet for CRUD operations.
        /// </summary>
        /// <param name="databaseObject"></param>
        /// <returns></returns>
        public static Lorry.Database.Haiku ToDbModel(this Lorry.Repository.Haikus.Haiku repositoryObject)
        {
            return mapper.Map<Lorry.Database.Haiku>(repositoryObject);
        }

        /// <summary>
        /// Converts Lorry.Database.Couplet object to TimecardRepository.Models.Couplet object.
        /// </summary>
        /// <param name="databaseObject"></param>
        /// <returns></returns>
        public static Lorry.Repository.Haikus.Haiku ToRepositoryModel(this Lorry.Database.Haiku databaseObject)
        {
            return mapper.Map<Lorry.Repository.Haikus.Haiku>(databaseObject);
        }

    }

}
