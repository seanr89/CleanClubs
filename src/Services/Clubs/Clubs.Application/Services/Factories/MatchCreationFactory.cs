
using System;
using System.Collections.Generic;
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


        public IMatchCreator GetMatchCreator()
        {
            throw new NotImplementedException();
        }

        public IMatchCreator GetBaseMatchCreator()
        {
            throw new NotImplementedException();
        }
    }
}