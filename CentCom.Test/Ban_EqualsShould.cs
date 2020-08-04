﻿using CentCom.Common.Models;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace CentCom.Test
{
    public class Ban_EqualsShould
    {
        [Fact]
        public void Equals_SameBanDifferentID_ReturnTrue()
        {
            var source = new BanSource()
            {
                Display = "test source",
                Name = "test",
                RoleplayLevel = RoleplayLevel.Medium,
                Id = 3
            };

            var banA = new Ban()
            {
                Id = 12,
                CKey = "test",
                BannedOn = DateTime.MinValue,
                BannedBy = "tester",
                BanType = BanType.Server,
                Reason = "what a great test",
                Source = source.Id,
                SourceNavigation = source
            };

            var banB = new Ban()
            {
                Id = 0,
                CKey = "test",
                BannedOn = DateTime.MinValue,
                BannedBy = "tester",
                BanType = BanType.Server,
                Reason = "what a great test",
                Source = source.Id,
                SourceNavigation = source
            };

            Assert.True(banA == banB, "Two bans equal by internal values should be equal");
            Assert.True(banA.GetHashCode() == banB.GetHashCode(), "Two bans equal by internal values should have equal hashcodes");
        }

        [Fact]
        public void Equals_SameBanDifferentIDDifferentSource_ReturnFalse()
        {
            var sourceA = new BanSource()
            {
                Display = "test source A",
                Name = "testA",
                RoleplayLevel = RoleplayLevel.Medium,
                Id = 3
            };

            var sourceB = new BanSource()
            {
                Display = "test source B",
                Name = "testB",
                RoleplayLevel = RoleplayLevel.Medium,
                Id = 4
            };

            var banA = new Ban()
            {
                Id = 12,
                CKey = "test",
                BannedOn = DateTime.MinValue,
                BannedBy = "tester",
                BanType = BanType.Server,
                Reason = "what a great test",
                Source = sourceA.Id,
                SourceNavigation = sourceA
            };

            var banB = new Ban()
            {
                Id = 0,
                CKey = "test",
                BannedOn = DateTime.MinValue,
                BannedBy = "tester",
                BanType = BanType.Server,
                Reason = "what a great test",
                Source = sourceB.Id,
                SourceNavigation = sourceB
            };

            Assert.False(banA == banB, "Two bans from different sources should not be equal by internal values");
            Assert.False(banA.GetHashCode() == banB.GetHashCode(), "Two bans from different sources should not have equal hashcodes");
        }

        [Fact]
        public void Equals_SameBanByBanID_ReturnTrue()
        {
            var banA = new Ban()
            {
                BanID = "epic",
                CKey = "doesn't matter"
            };

            var banB = new Ban()
            {
                BanID = "epic",
                CKey = "different"
            };

            Assert.True(banA == banB, "Two bans with BanIDs should be checked for equality by ID");
            Assert.True(banA.GetHashCode() == banB.GetHashCode(), "Two bans with BanIDs that are equal should have equal hashcodes");
        }

        [Fact]
        public void Equals_SameBanIDDifferentSource_ReturnFalse()
        {
            var sourceA = new BanSource()
            {
                Display = "test source A",
                Name = "testA",
                RoleplayLevel = RoleplayLevel.Medium,
                Id = 3
            };

            var sourceB = new BanSource()
            {
                Display = "test source B",
                Name = "testB",
                RoleplayLevel = RoleplayLevel.Medium,
                Id = 4
            };

            var banA = new Ban()
            {
                BanID = "epic",
                CKey = "doesn't matter",
                Source = sourceA.Id,
                SourceNavigation = sourceA
            };

            var banB = new Ban()
            {
                BanID = "epic",
                CKey = "different",
                Source = sourceB.Id,
                SourceNavigation = sourceB
            };

            Assert.False(banA == banB, "Two bans from different sources should not be equal by BanID");
            Assert.False(banA.GetHashCode() == banB.GetHashCode(), "Two bans from different sources should not have equal hashcodes");
        }

        [Fact]
        public void Equals_SameBanDifferentJobOrder_ReturnTrue()
        {
            var banA = new Ban()
            {
                Id = 12,
                JobBans = new HashSet<JobBan>()
                {
                    new JobBan() { Job = "captain" },
                    new JobBan() { Job = "assistant" }
                }
            };

            var banB = new Ban()
            {
                Id = 0,
                JobBans = new HashSet<JobBan>()
                {
                    new JobBan() { Job = "assistant" },
                    new JobBan() { Job = "captain" }
                }
            };

            Assert.True(banA == banB, "Two bans with the same jobbans in different orders should be equal");
            Assert.True(banA.GetHashCode() == banB.GetHashCode(), "Two bans with the same jobbans in different orders should be equal");
        }

        [Fact]
        public void Equals_SameBanNullVsEmptyJobBans_ReturnTrue()
        {
            var banA = new Ban()
            {
                Id = 0,
                Source = 15,
                BanType = BanType.Server,
                JobBans = null
            };

            var banB = new Ban()
            {
                Id = 0,
                Source = 15,
                BanType = BanType.Server,
                JobBans = new HashSet<JobBan>()
            };

            Assert.True(banA == banB, "Bans should be equal if the jobbans only differ by null and an empty set");
            Assert.True(banA.GetHashCode() == banB.GetHashCode(), "Bans should have the same hashcode if the jobbans only differ by null and an empty set");
        }

        [Fact]
        public void Equals_SameBansSameIP_ReturnsTrue()
        {
            var banA = new Ban()
            {
                Id = 193912,
                Source = 84,
                BanType = BanType.Server,
                CKey = "kinler101",
                BannedOn = DateTime.Parse("2020-08-03T22:23:58Z"),
                BannedBy = "archsunder",
                Reason = "testing reason",
                IP = IPAddress.Parse("108.20.220.45")
            };

            var banB = new Ban()
            {
                Id = 0,
                Source = 84,
                BanType = BanType.Server,
                CKey = "kinler101",
                BannedOn = DateTime.Parse("2020-08-03T22:23:58Z"),
                BannedBy = "archsunder",
                Reason = "testing reason",
                IP = IPAddress.Parse("108.20.220.45")
            };

            Assert.True(banA == banB, "Bans should be equal if all values are equal, including IP");
            Assert.True(banA.GetHashCode() == banB.GetHashCode(), "Bans should have the same hashcode if all values are equal, including IP");
        }
    }
}
