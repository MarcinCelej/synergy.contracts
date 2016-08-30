using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Synergy.Contracts.Test.Failures
{
    [TestFixture]
    public class FailCollectionTest
    {
        [Test]
        public void IfCollectionContains()
        {
            var kolekcja = new[] {new object(), "element"};

            Assert.Throws<DesignByContractViolationException>(
                () => Fail.IfCollectionContains(kolekcja, e => object.Equals(objA: e, objB: "ala"), "ta kolekcja ma 'ala'")
            );

            Fail.IfCollectionContains(kolekcja, e => object.Equals(objA: e, objB: "dziwny"), "ta kolekcja NIE ma elementu dziwnego");
        }

        [Test]
        public void IfCollectionContainsNull()
        {
            var zNullem = new[] {new object(), null};
            IEnumerable<string> pe�na = Enumerable.Repeat("element", 2);

            Assert.Throws<DesignByContractViolationException>(
                () => Fail.IfCollectionContainsNull(zNullem, "zNullem")
            );

            Fail.IfCollectionContainsNull(pe�na, "pe�na");
        }

        [Test]
        public void IfCollectionNullOrEmpty()
        {
            IEnumerable<object> pusta = Enumerable.Empty<object>();
            IEnumerable<object> nullowata = null;
            IEnumerable<string> pe�na = Enumerable.Repeat("element", 2);

            Assert.Throws<DesignByContractViolationException>(
                () => Fail.IfCollectionNullOrEmpty(pusta, "collection")
            );

            Assert.Throws<DesignByContractViolationException>(
                () => Fail.IfCollectionNullOrEmpty(nullowata, "collection")
            );

            Fail.IfCollectionNullOrEmpty(pe�na, "collection");
        }

        [Test]
        public void IfCollectionsAreNotEquivalent()
        {
            var kolekcja1 = new[] {"ala", "olo"};
            var kolekcja1InnaKolejno�� = new[] {"olo", "ala"};
            var kolekcja2 = new[] {"ala", "inna"};
            var pusta1 = new string[0];
            var pusta2 = new List<string>();

            Assert.Throws<DesignByContractViolationException>(
                () => Fail.IfCollectionsAreNotEquivalent(collection1: kolekcja1, collection2: kolekcja2, "s� r�ne")
            );

            Fail.IfCollectionsAreNotEquivalent(collection1: kolekcja1, collection2: kolekcja1InnaKolejno��, "s� r�ne");
            Fail.IfCollectionsAreNotEquivalent(collection1: pusta1, collection2: pusta2, "s� r�ne");
        }
    }
}