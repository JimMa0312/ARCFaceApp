//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ARCSoftFaceApp.EntityFrameDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_dept
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_dept()
        {
            this.t_teacher = new HashSet<t_teacher>();
        }
    
        public int dept_id { get; set; }
        public int college_id { get; set; }
        public string dept_name { get; set; }
        public string dept_describes { get; set; }
    
        public virtual t_college t_college { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_teacher> t_teacher { get; set; }
    }
}