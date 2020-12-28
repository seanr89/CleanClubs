using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Clubs.Domain.Common;

namespace Clubs.Domain.Entities
{
    public class Club : AuditableEntity
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        /// <summary>
        /// TODO: to be removed!
        /// </summary>
        /// <value></value>
        public string Creator { get; set; } = "Unknown";
        /// <summary>
        /// User based Creator - TODO Included
        /// </summary>
        /// <value></value>
        public User Founder { get; set; }

        public ICollection<Member> Members { get; set; }

        /// <summary>
        /// Record of matches played by a club
        /// </summary>
        /// <value></value>
        public ICollection<Match> Matches { get; set; }

        /// <summary>
        /// Identifies in future if the club is private
        /// </summary>
        /// <value></value>
        public bool Private { get; set; } = false;

        /// <summary>
        /// TODO: private, parameterless constructor used by EF Core
        /// </summary>
        public Club() { }

        /// <summary>
        /// new parameter based constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="active"></param>
        /// <param name="privateClub"></param>
        /// <param name="creator"></param>
        public Club(string name, bool active, bool privateClub, string creator)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            Active = active;
            Private = privateClub;
            Creator = creator;
        }

        #region Public Setters

        /// <summary>
        /// Provides addition of member to the club member list
        /// BUT DOES NOT SAVE!
        /// </summary>
        /// <param name="member"></param>
        public void AddMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            this.Members.Add(member);
        }

        public void Activate() => Active = true;
        public void DeActivate() => Active = false;

        #endregion
    }
}