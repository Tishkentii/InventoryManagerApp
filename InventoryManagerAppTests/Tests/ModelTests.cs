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
        //[TestCaseSource(typeof(ModelTestData), "Roll_ValidData")]
        //public void Roll_Constructor_ValidParams_ReturnsRoll(int id, RollType type, string producesBy, int width, int thickness, double length, double weight, string comment, DateTime createdOn, DateTime? consumedOn)
        //{
        //    var sut = new Roll(id, type, producesBy, width, thickness, length, weight, comment, createdOn, consumedOn);
        //    Assert.That(sut.RollID, Is.GreaterThan(0), "id 0 or negative");
        //    Assert.IsTrue(!String.IsNullOrEmpty(sut.ProducedBy), "producedby is empty");
        //    Assert.That(sut.Width, Is.GreaterThan(0), "width 0 or negative");
        //    Assert.That(sut.Thickness, Is.GreaterThan(0), "thickness 0 or negative");
        //    Assert.That(sut.Length, Is.GreaterThan(0), "length 0 or negative");
        //    if (consumedOn != null)
        //        Assert.That(sut.CreatedOn, Is.LessThan(sut.ConsumedOn), "created greater than consumed");
        //}

        //[TestCaseSource(typeof(ModelTestData), "Roll_InvalidData")]
        //public void Roll_Constructor_InvalidParams_ThrowsArgument(int id, RollType type, string producesBy, int width, int thickness, double length, double weight, string comment, DateTime createdOn, DateTime? consumedOn)
        //{
        //    Assert.Throws<ArgumentException>(() => new Roll(id, type, producesBy, width, thickness, length, weight, comment, createdOn, consumedOn));
        //}

        //[TestCaseSource(typeof(ModelTestData), "RollSummary_ValidData")]
        //public void RollSummary_Constructor_ValidParamas_ReturnsRollSummary(RollType type, int rollCount, int width, int thickness, double totalLength, double totalWeight, DateTime lastDateCreated, DateTime firstDateCreated)
        //{
        //    var sut = new RollSummary(type, rollCount, width, thickness, totalLength, totalWeight, lastDateCreated, firstDateCreated);
        //    Assert.That(sut.RollCount, Is.GreaterThanOrEqualTo(0), "rollCount negative");
        //    Assert.That(sut.Width, Is.GreaterThan(0), "width 0 or negative");
        //    Assert.That(sut.Thickness, Is.GreaterThan(0), "thickness 0 or negative");
        //    Assert.That(sut.TotalLength, Is.GreaterThanOrEqualTo(0), "totalLength negative");
        //    Assert.That(sut.TotalWeight, Is.GreaterThanOrEqualTo(0), "totalWeight negative");
        //    Assert.That(sut.LastDateCreated, Is.GreaterThanOrEqualTo(sut.FirstDateCreated), "last is less than first");
        //}

        //[TestCaseSource(typeof(ModelTestData), "RollSummary_InvalidData")]
        //public void RollSummary_Constructor_InvalidParams_ThrowsArgument(RollType type, int rollCount, int width, int thickness, double totalLength, double totalWeight, DateTime lastDateCreated, DateTime firstDateCreated)
        //{
        //    Assert.Throws<ArgumentException>(() => new RollSummary(type, rollCount, width, thickness, totalLength, totalWeight, lastDateCreated, firstDateCreated));
        //}
    }
}
