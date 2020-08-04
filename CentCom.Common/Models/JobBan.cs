﻿using System;
using System.Text.Json.Serialization;

namespace CentCom.Common.Models
{
    public class JobBan : IEquatable<JobBan>
    {
        public int BanId { get; set; }
        [JsonIgnore]
        public virtual Ban BanNavigation { get; set; }
        public string Job { get; set; }

        public bool Equals(JobBan other)
        {
            return !(other is null) && Job == other.Job;
        }

        public static bool operator ==(JobBan a, JobBan b) 
        {
            return (a is null && b is null) || a.Equals(b);
        }

        public static bool operator !=(JobBan a, JobBan b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return (obj is JobBan jb) && Equals(jb);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Job, StringComparer.OrdinalIgnoreCase);
            return hash.ToHashCode();
        }
    }
}
