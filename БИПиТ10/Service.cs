//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace БИПиТ10
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.Order = new HashSet<Order>();
        }

        [Display(Name = "Id услуги")]
        public int IdS { get; set; }

        [Required]
        [RegularExpression(@"([а-яa-zА-ЯA-Z\s]+)", ErrorMessage = "Некорректное поле Услуга.")]
        [DisplayName("Услуга")]
        public string Service1 { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
