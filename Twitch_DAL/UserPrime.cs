//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Twitch_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserPrime
    {
        public int userPrimeId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> primeId { get; set; }
    
        public virtual Prime Prime { get; set; }
        public virtual User User { get; set; }
    }
}
