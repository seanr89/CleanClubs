using System;
using System.Threading.Tasks;
using AutoMapper;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Services.Interfaces;
using Clubs.Domain.Entities;
using Clubs.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.Application.Services
{
    public abstract class BaseMatchCreator : IMatchCreator
    {
        protected readonly ILogger<IMatchCreator> _Logger;
        protected readonly ClubsContext _DbContext;
        protected readonly IMapper _Mapper;
        protected BaseMatchCreator(ILogger<IMatchCreator> logger
            , ClubsContext context
            , IMapper mapper)
        {
            _Logger = logger;
            _DbContext = context;
            _Mapper = mapper;
        }

        public virtual async Task<Guid?> Create(object match)
        {
            _Logger.LogInformation($"BaseMatchCreator: {HelperMethods.GetCallerMemberName()}");
            //Now execute the save process!
            return await this.SaveNewMatch(_Mapper.Map<Match>(match));
        }

        #region Protected

        /// <summary>
        /// DB operation event to save a new match record
        /// </summary>
        /// <param name="match">match to be saved</param>
        /// <returns>a new GUID parameter to denote the match!</returns>
        protected async Task<Guid?> SaveNewMatch(Match match)
        {
            try{
                _DbContext.Matches.Add(match);
                await _DbContext.SaveChangesAsync();
                return match.Id;
            }
            catch(SqlException se)
            {
                _Logger.LogInformation($"{HelperMethods.GetCallerMemberName()} : Exception {se.Message}");
                return null;
            }
            catch(DbUpdateException de)
            {
                _Logger.LogInformation($"{HelperMethods.GetCallerMemberName()} : Exception {de.Message}");
                return null;
            }
        }

        #endregion
    }
}