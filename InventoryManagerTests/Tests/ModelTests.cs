using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerAppTests.TestData;
using InventoryManagerModel;
using InventoryManagerModel.DTOs;
using InventoryManagerModel.Entities;
using NUnit.Framework;

namespace InventoryManagerAppTests.Tests
{
    [TestFixture]
    public class ModelTests
    {
        #region RollSize Constructor Tests

        [TestCaseSource(typeof(ModelTestData), "RollSize_ValidData")]
        public void RollSizeConstructor_ValidParams_Constructed(int id, RollType type, int width, int thickness)
        {
            var sut = new RollSize(id, type, width, thickness);

            Assert.That(sut.SizeID, Is.EqualTo(id));
            Assert.That(sut.Type, Is.EqualTo(type));
            Assert.That(sut.Width, Is.EqualTo(width));
            Assert.That(sut.Thickness, Is.EqualTo(thickness));
        }

        [TestCaseSource(typeof(ModelTestData), "RollSize_InvalidData")]
        public void RollSizeConstructor_InvalidParams_ThrowsArgument(int id, RollType type, int width, int thickness)
        {
            Assert.Throws<ArgumentException>(() => new RollSize(id, type, width, thickness));
        }

        #endregion

        #region Roll Constructor Tests

        [TestCaseSource(typeof(ModelTestData), "Roll_ValidData")]
        public void RollConstructor_ValidParams_Constructed(int id, RollSize size, string producedBy, double length, double weight, string notes, DateTime createdOn, DateTime? consumedOn)
        {
            var sut = new Roll(id, size, producedBy, length, weight, notes, createdOn, consumedOn);

            Assert.That(sut.RollID, Is.EqualTo(id));
            Assert.That(sut.Size, Is.EqualTo(size));
            Assert.That(sut.ProducedBy, Is.EqualTo(producedBy));
            Assert.That(sut.Length, Is.EqualTo(length));
            Assert.That(sut.Weight, Is.EqualTo(weight));
            Assert.That(sut.Notes, Is.EqualTo(notes));
            Assert.That(sut.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(sut.ConsumedOn, Is.EqualTo(consumedOn));
        }

        [TestCaseSource(typeof(ModelTestData), "Roll_InvalidData")]
        public void RollConstructor_InvalidParams_ThrowsArgument(int id, RollSize size, string producedBy, double length, double weight, string notes, DateTime createdOn, DateTime? consumedOn)
        {
            Assert.Throws<ArgumentException>(() => new Roll(id, size, producedBy, length, weight, notes, createdOn, consumedOn));
        }

        [TestCaseSource(typeof(ModelTestData), "Roll_NullData")]
        public void RollConstructor_NullParam_ThrowsArgumentNull(int id, RollSize size, string producedBy, double length, double weight, string notes, DateTime createdOn, DateTime? consumedOn)
        {
            Assert.Throws<ArgumentNullException>(() => new Roll(id, size, producedBy, length, weight, notes, createdOn, consumedOn));
        }

        #endregion

        #region RollSummary Constructor Tests

        [TestCaseSource(typeof(ModelTestData), "RollSummary_ValidData")]
        public void RollSummaryConstructor_ValidParams_Constructed(RollSize rollSize, int rollCount, double totalLength, double totalWeight, DateTime? firstDateCreated, DateTime? lastDateCreated)
        {
            var sut = new RollSummary(rollSize, rollCount, totalLength, totalWeight, firstDateCreated, lastDateCreated);

            Assert.That(sut.RollSize, Is.EqualTo(rollSize));
            Assert.That(sut.RollCount, Is.EqualTo(rollCount));
            Assert.That(sut.TotalLength, Is.EqualTo(totalLength));
            Assert.That(sut.TotalWeight, Is.EqualTo(totalWeight));
            Assert.That(sut.LastDateCreated, Is.EqualTo(lastDateCreated));
            Assert.That(sut.FirstDateCreated, Is.EqualTo(firstDateCreated));
        }

        [TestCaseSource(typeof(ModelTestData), "RollSummary_InvalidData")]
        public void RollSummaryConstructor_InvalidParams_ThrowsArgument(RollSize rollSize, int rollCount, double totalLength, double totalWeight, DateTime? firstDateCreated, DateTime? lastDateCreated)
        {
            Assert.Throws<ArgumentException>(() => new RollSummary(rollSize, rollCount, totalLength, totalWeight, firstDateCreated, lastDateCreated));
        }

        [TestCaseSource(typeof(ModelTestData), "RollSummary_NullData")]
        public void RollSummaryConstructor_NullParams_ThrowsArgumentNull(RollSize rollSize, int rollCount, double totalLength, double totalWeight, DateTime? firstDateCreated, DateTime? lastDateCreated)
        {
            Assert.Throws<ArgumentNullException>(() => new RollSummary(rollSize, rollCount, totalLength, totalWeight, firstDateCreated, lastDateCreated));
        }

        #endregion
    }
}
