namespace _02.FitGym.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using NUnit.Framework;
    using _02.FitGym;

    public class FitGymTests
    {
        private IGym gym;

        private Member mem1;
        private Member mem2;
        private Member mem3;
        private Member mem4;
        private Member mem5;

        private Trainer train1;
        private Trainer train2;
        private Trainer train3;
        private Trainer train4;
        private Trainer train5;


        [SetUp]
        public void Setup()
        {
            this.gym = new FitGym();
            this.mem1 = new Member(1, "a", new DateTime(2020, 3, 3), 2);
            this.mem2 = new Member(2, "b", new DateTime(2020, 2, 2), 1);
            this.mem3 = new Member(3, "c", new DateTime(2020, 1, 1), 3);
            this.mem4 = new Member(4, "c", new DateTime(2010, 1, 1), 3);
            this.mem5 = new Member(5, "d", new DateTime(2022, 1, 1), 3);
            this.train1 = new Trainer(1, "a", 2);
            this.train2 = new Trainer(2, "b", 3);
            this.train3 = new Trainer(3, "c", 1);
            this.train4 = new Trainer(4, "d", 0);
            this.train5 = new Trainer(5, "d", 99);
        }

        [Test]
        public void TestAddMember()
        {
            this.gym.AddMember(mem1);

            Assert.True(this.gym.Contains(mem1));
            Assert.AreEqual(1, this.gym.MemberCount);
        }

        [Test]
        public void TestAddMemberExists()
        {
            this.gym.AddMember(mem1);
            Assert.Throws<ArgumentException>(() => this.gym.AddMember(mem1));
        }

        [Test]
        public void TestAddMultipleMembers()
        {
            Assert.AreEqual(0, this.gym.MemberCount);

            this.gym.AddMember(mem1);
            this.gym.AddMember(mem2);
            this.gym.AddMember(mem3);

            Assert.AreEqual(3, this.gym.MemberCount);
            Assert.True(this.gym.Contains(mem1));
            Assert.True(this.gym.Contains(mem2));
            Assert.True(this.gym.Contains(mem3));
        }

        [Test]
        public void TestAddTrainer()
        {
            Assert.AreEqual(0, this.gym.TrainerCount);
            this.gym.HireTrainer(train1);

            Assert.True(this.gym.Contains(train1));
            Assert.AreEqual(1, this.gym.TrainerCount);
        }

        [Test]
        public void TestAddTrainerAlreadyExist()
        {
            Assert.AreEqual(0, this.gym.TrainerCount);
            this.gym.HireTrainer(train1);
            Assert.Throws<ArgumentException>(() => this.gym.HireTrainer(train1));
        }

        [Test]
        public void TestAddMultipleTrainers()
        {
            Assert.AreEqual(0, this.gym.TrainerCount);

            this.gym.HireTrainer(train1);
            this.gym.HireTrainer(train2);
            this.gym.HireTrainer(train3);

            Assert.AreEqual(3, this.gym.TrainerCount);
            Assert.True(this.gym.Contains(train1));
            Assert.True(this.gym.Contains(train2));
            Assert.True(this.gym.Contains(train3));
        }

        [Test]
        public void TestAddTrainerToMember()
        {
            this.gym.HireTrainer(train1);
            this.gym.Add(train1, mem1);

            Assert.True(this.gym.Contains(train1));
            Assert.True(this.gym.Contains(mem1));

            var mem = this.gym.GetMembersInOrderOfRegistrationAscendingThenByNamesDescending().ToList()[0];
            Assert.AreEqual(mem, mem1);
        }

        [Test]
        public void TestAddTrainerToMemberThrow()
        {
            Assert.Throws<ArgumentException>(() => this.gym.Add(train1, mem1));
        }

        [Test]
        public void TestAddTrainerToMemberV2()
        {
            this.gym.HireTrainer(train1);
            this.gym.AddMember(mem1);
            this.gym.Add(train1, mem1);

            Assert.True(this.gym.Contains(train1));
            Assert.True(this.gym.Contains(mem1));
            var mem = this.gym.GetMembersInOrderOfRegistrationAscendingThenByNamesDescending().ToList()[0];
            Assert.AreEqual(mem, mem1);
        }

        [Test]
        public void TestContainsWithMembers()
        {
            Assert.False(this.gym.Contains(mem1));
            this.gym.AddMember(mem1);
            Assert.True(this.gym.Contains(mem1));
            Assert.False(this.gym.Contains(mem2));
        }

        [Test]
        public void TestContainsWithTrainers()
        {
            Assert.False(this.gym.Contains(train1));
            this.gym.HireTrainer(train1);
            Assert.True(this.gym.Contains(train1));
            Assert.False(this.gym.Contains(train2));
        }

        [Test]
        public void TestFireTrainer()
        {
            this.gym.HireTrainer(train1);
            this.gym.FireTrainer(train1.Id);
            Assert.False(this.gym.Contains(train1));
        }

        [Test]
        public void TestFireTrainerThrowException()
        {
            Assert.Throws<ArgumentException>(() => this.gym.FireTrainer(train1.Id));
        }

        [Test]
        public void TestMemberCountZeroMembers()
        {
            this.gym.AddMember(mem1);
            this.gym.RemoveMember(mem1.Id);

            Assert.AreEqual(0, this.gym.MemberCount);
        }

        [Test]
        public void TestMemberCountOneMember()
        {
            this.gym.AddMember(mem1);

            Assert.AreEqual(1, this.gym.MemberCount);
        }

        [Test]
        public void TestMemberCountMultipleMembers()
        {
            this.gym.AddMember(mem1);
            this.gym.AddMember(mem2);
            this.gym.AddMember(mem3);
            Assert.AreEqual(3, this.gym.MemberCount);

            this.gym.RemoveMember(mem2.Id);
            Assert.AreEqual(2, this.gym.MemberCount);

            this.gym.AddMember(mem2);
            Assert.AreEqual(3, this.gym.MemberCount);
        }

        [Test]
        public void TestTrainerCountZeroTrainers()
        {
            this.gym.HireTrainer(train1);
            this.gym.FireTrainer(train1.Id);

            Assert.AreEqual(0, this.gym.TrainerCount);
        }

        [Test]
        public void TestTrainerCountOneTrainer()
        {
            this.gym.HireTrainer(train1);

            Assert.AreEqual(1, this.gym.TrainerCount);
        }

        [Test]
        public void TestTrainerCountMultipleTrainers()
        {
            this.gym.HireTrainer(train1);
            this.gym.HireTrainer(train2);
            this.gym.HireTrainer(train3);

            Assert.AreEqual(3, this.gym.TrainerCount);

            this.gym.FireTrainer(train2.Id);
            Assert.AreEqual(2, this.gym.TrainerCount);

            this.gym.HireTrainer(train2);
            Assert.AreEqual(3, this.gym.TrainerCount);
        }

        [Test]
        public void TestGetMembersInOrderOfRegistrationAscendingThenByNamesDescendingNoMembers()
        {
            var members = this.gym.GetMembersInOrderOfRegistrationAscendingThenByNamesDescending();
            CollectionAssert.AreEquivalent(members, new List<Member>());
        }

        [Test]
        public void TestGetMembersInOrderOfRegistrationAscendingThenByNamesDescendingManyMembers()
        {
            this.gym.AddMember(mem1);
            this.gym.AddMember(mem2);
            this.gym.AddMember(mem3);
            this.gym.AddMember(mem4);
            this.gym.AddMember(mem5);

            var mems = this.gym.GetMembersInOrderOfRegistrationAscendingThenByNamesDescending();
            var expected = new List<Member> { mem4, mem3, mem2, mem1, mem5 };
            CollectionAssert.AreEqual(expected, mems);
        }

        [Test]
        public void TestGetTrainersInOrderOfPopularityOnlyOneTrainer()
        {
            this.gym.HireTrainer(train1);

            var trainees = this.gym.GetTrainersInOrdersOfPopularity();
            CollectionAssert.AreEqual(trainees, new List<Trainer>() { train1 });
        }
        [Test]
        public void TestGetTrainersInPopularityManyTrainers()
        {
            this.gym.HireTrainer(train1);
            this.gym.HireTrainer(train2);
            this.gym.HireTrainer(train3);
            this.gym.HireTrainer(train4);
            this.gym.HireTrainer(train5);

            var trainees = this.gym.GetTrainersInOrdersOfPopularity();
            var expected = new List<Trainer>() { train4, train3, train1, train2, train5 };
            CollectionAssert.AreEqual(expected, trainees);
        }

        [Test]
        public void TestGetTrainerMembersSortedByRegistrationDateThenByNames()
        {
            this.gym.HireTrainer(train1);
            this.gym.Add(train1, mem1);
            this.gym.Add(train1, mem2);
            this.gym.Add(train1, mem3);
            this.gym.Add(train1, mem4);
            this.gym.Add(train1, mem5);

            var mems = this.gym.GetTrainerMembersSortedByRegistrationDateThenByNames(train1);
            var expected = new List<Member> { mem4, mem3, mem2, mem1, mem5 };
            CollectionAssert.AreEqual(expected, mems);
        }

        [Test]
        public void TestGetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames()
        {
            this.gym.HireTrainer(train1);
            this.gym.HireTrainer(train2);
            this.gym.HireTrainer(train3);
            this.gym.HireTrainer(train4);
            this.gym.HireTrainer(train5);
            this.gym.Add(train1, mem1);
            this.gym.Add(train2, mem2);
            this.gym.Add(train3, mem4);
            this.gym.Add(train4, mem3);
            this.gym.Add(train5, mem5);

            var mems = this.gym.GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(1, 3);
            var expected = new List<Member> { mem2, mem1, mem4 };
            CollectionAssert.AreEqual(expected, mems);
        }

        [Test]
        public void TestGetTrainersAndItsMemberOrderedByTrainersMembersCountThenByTrainersPopularity()
        {
            this.gym.HireTrainer(train1);
            this.gym.HireTrainer(train2);
            this.gym.HireTrainer(train3);
            this.gym.Add(train1, mem1);
            this.gym.Add(train1, mem2);
            this.gym.Add(train2, mem3);
            this.gym.Add(train2, mem4);
            this.gym.Add(train3, mem5);

            var trainersAndMems = this.gym.GetTrainersAndMemberOrderedByMembersCountThenByPopularity();
            var expected = new Dictionary<Trainer, List<Member>>() {
                { train3, new List<Member>() { mem5} },
                { train1, new List<Member>() { mem1, mem2} },
                { train2, new List<Member>() { mem3, mem4} },
            };

            CollectionAssert.AreEquivalent(expected, trainersAndMems);
        }
    }
}