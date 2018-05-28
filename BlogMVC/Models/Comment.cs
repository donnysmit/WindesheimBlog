using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        /* Als je handmatig een foreign key toevoegt (zoals wij met PostID en UserID hebben gedaan, zodat Scaffolding de dropdown maakt)
         * dan zet Entity Framework dit veld in de database gelijk op non-nullable (zodat een Comment ALTIJD een user en een post moet hebben)
         * en ten tweede zet hij Cascading Delete aan. Dit zorgt ervoor dat als je een Post weghaalt, hij ook alle Comments delete
         * Of als je een User weghaalt, hij alle Posts en Comments van die user weghaalt.
         * Dit is heel handig, maar bij ons raakt ie in de war, doordat posts een user hebben en comments, maar comments ook een user
         * hij kan dan met deleten in een loop raken of dingen 2x proberen te deleten.
         * Dit was de foutmelding in de les.
         * 
         * Om dit op te lossen heb ik de Cascading delete tussen Comments en Posts even uitgezet in de migrations file.
         * Niet zo netjes, want als je nu een Post weghaalt blijven de Comments staat, maar dit was even de snelste oplossing
         */
        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public Comment()
        {
            Created = DateTime.Now;
        }
    }
}
 