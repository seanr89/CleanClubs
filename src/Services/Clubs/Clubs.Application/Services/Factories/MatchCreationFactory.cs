
using System;
using System.Collections.Generic;
using System.Linq;
using Clubs.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Services.Factories
{
    public class MatchCreationFactory
    {
        private readonly IEnumerable<IMatchCreator> _Creators;
        public MatchCreationFactory(IEnumerable<IMatchCreator> availableCreators)
        {
            _Creators = availableCreators;
        }

        #region Public Accessors

        /// <summary>
        /// Returh a match creator that supports invitation creation etc
        /// </summary>
        /// <returns>IMatchCreator</returns>
        public IMatchCreator GetInvitationMatchCreator()
        {
            return GetMatchCreatorByType(typeof(InvitationMatchCreator));
        }

        /// <summary>
        /// Query the default/simple match creator
        /// No invitations or alerts are producted through this!
        /// </summary>
        /// <returns>IMatchCreator</returns>
        public IMatchCreator GetBaseMatchCreator()
        {
            return GetMatchCreatorByType(typeof(SimpleMatchCreator));
        }
        
        /// <summary>
        /// Base operation to attempt to query for a match creator by a provided type
        /// </summary>
        /// <param name="type">Object Type</param>
        /// <returns>IMatchCreator</returns>
        public IMatchCreator TryFindMatchCreatorByType(Type type)
        {
            IMatchCreator res = GetMatchCreatorByType(type);
            return res;
        }

        #endregion

        /// <summary>
        /// Query records based on an object type
        /// </summary>
        /// <param name="type">Type paramter of expected class!</param>
        /// <returns>IMatchCreator or null</returns>
        IMatchCreator GetMatchCreatorByType(Type type)
        {
            try{  
                List<IMatchCreator> records = _Creators.ToList();
                return records.FirstOrDefault(i => i.GetType() == type);
            }
            catch{
                return null;
            }
        }
    }
}