using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using permute.me.Permutators;

namespace permute.me.UnitTests.Permutators {

    [TestFixture]
    public class PermutatorTests {

        public static IEnumerable<PermutatorFactory> Permutators {
            get {
                yield return new PermutatorFactory("LexicalPermutator", s => new LexicalPermutator(s));
                // Add new implementations here
            }
        }

        [Test(Description = "permutation with 2 elements")]
        [TestCaseSource("Permutators")]
        public void TestPermutators2(PermutatorFactory factory) {
            var permutations = factory.Build("a", "b").ToList();

            permutations.Should().HaveCount(2);
            permutations.Should().Contain("ab").And.Contain("ba");
            permutations.Distinct().Count().Should().Be(permutations.Count);
        }

        [Test(Description="permutation with 3 elements")]
        [TestCaseSource("Permutators")]
        public void TestPermutators3(PermutatorFactory factory) {
            var permutations = factory.Build("a", "b", "c").ToList();

            permutations.Should().HaveCount(6);
            permutations.Should().Contain("abc").And.Contain("acb")
                .And.Contain("bac").And.Contain("bca")
                .And.Contain("cab").And.Contain("cba");
            permutations.Distinct().Count().Should().Be(permutations.Count);
        }

    }

    public class PermutatorFactory {
        public string TestName { get; private set; }
        private Func<IEnumerable<string>, IEnumerable<string>> Factory { get; set; }

        public PermutatorFactory(string testName, Func<IEnumerable<string>,IEnumerable<string>> factory) {
            this.TestName = testName;
            this.Factory = factory;
        }

        public IEnumerable<string> Build(params string[] parts) {
            return Factory(parts);
        }
    }
}
