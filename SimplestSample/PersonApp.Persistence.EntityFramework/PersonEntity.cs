using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.Persistence.EntityFramework
{
    [Table("Person")]
    class PersonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        /// <summary>
        /// For soft deleting entities
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
