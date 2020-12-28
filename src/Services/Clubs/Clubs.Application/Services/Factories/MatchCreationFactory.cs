
using System;
using System.Collections.Generic;
using System.Linq;
using Clubs.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Services.Factories
{
    public class MatchCreationFactory
    {
        private readonly ILogger _Logger;
        private readonly IEnumerable<IMatchCreator> _Creators;
        public MatchCreationFactory(IEnumerable<IMatchCreator> availableCreators)
        {
            _Creators = availableCreators;
        }

        public IMatchCreator GetInvitationMatchCreator()
        {
            var item = GetMatchCreatorByType(typeof(InvitationMatchCreator));
            return this._Creators.ToList()[1];
        }

        public IMatchCreator GetBaseMatchCreator()
        {
            var item = GetMatchCreatorByType(typeof(SimpleMatchCreator));
            return this._Creators.ToList()[0];
        }

        /// <summary>
        /// Test method to attempt to query records based on an object type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IMatchCreator GetMatchCreatorByType(object type)
        {
            List<IMatchCreator> records = _Creators.ToList();

            var item = records.Find(i => i.GetType() == type.GetType());

            return item;
        }
    }
}