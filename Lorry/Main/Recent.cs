using System;
using System.Collections.Generic;

namespace Lorry.Main
{
    public partial class Recent
    {
        public int RecentId { get; set; }
        public string RecentContent { get; set; }
        public string RecentType { get; set; }
        public string RecentDate { get; set; }
    }

    public static class RecentMapperExtension
    {

        // Create AutoMapper configuration for mapping database model objects to repository model objects
        public static AutoMapper.MapperConfiguration mapperConfig = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Lorry.Repository.Recents.Recent, Lorry.Main.Recent>().ReverseMap());
        public static AutoMapper.IMapper mapper = mapperConfig.CreateMapper();

        /// <summary>
        /// Converts TimecardRepository.Models.Couplet object to Database object Lorry.Database.Couplet for CRUD operations.
        /// </summary>
        /// <param name="databaseObject"></param>
        /// <returns></returns>
        public static Lorry.Repository.Recents.Recent ToRepositoryModel(this Lorry.Main.Recent applicationObject)
        {
            return mapper.Map<Lorry.Repository.Recents.Recent>(applicationObject);
        }

        /// <summary>
        /// Converts Lorry.Database.Couplet object to TimecardRepository.Models.Couplet object.
        /// </summary>
        /// <param name="databaseObject"></param>
        /// <returns></returns>
        public static Lorry.Main.Recent ToUIModel(this Lorry.Repository.Recents.Recent repositoryObject)
        {
            return mapper.Map<Lorry.Main.Recent>(repositoryObject);
        }

    }

}
