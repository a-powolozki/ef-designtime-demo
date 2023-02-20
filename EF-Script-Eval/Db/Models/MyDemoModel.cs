using System.ComponentModel.DataAnnotations;

namespace EF_Script_Eval.Db.Models
{
    public class MyDemoModel
    {
        public int Id { get; set; }

        [MaxLength(512)]
        public string PropertyOne { get; set; }
        public int PropertyTwo { get; set; }
    }
}
