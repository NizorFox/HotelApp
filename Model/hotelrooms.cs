
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace HotelApp.Model
{

using System;
    using System.Collections.Generic;
    
public partial class hotelrooms
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public hotelrooms()
    {

        this.hardware_table = new HashSet<hardware_table>();

        this.listresidents = new HashSet<listresidents>();

        this.room_hardware = new HashSet<room_hardware>();

    }


    public string number_room { get; set; }

    public int places { get; set; }

    public int rooms { get; set; }

    public int id_class { get; set; }

    public byte bathroom { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<hardware_table> hardware_table { get; set; }

    public virtual hotelroom_classes hotelroom_classes { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<listresidents> listresidents { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<room_hardware> room_hardware { get; set; }

}

}