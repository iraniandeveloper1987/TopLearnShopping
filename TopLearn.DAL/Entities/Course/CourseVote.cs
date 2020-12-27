using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopLearn.DAL.Entities.Course
{
    public class CourseVote
    {
        [Key]
        public int CourseVoteId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public bool Vote { get; set; }

        [Required]
        public DateTime VoteDate { get; set; } = DateTime.Now;

        #region Relations (Navigation Properties)

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        #endregion
    }
}
