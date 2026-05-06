using System.Collections;
using JetBrains.Annotations;
using Meetline.Modules.SharedKernel.Domain.Wrappers;

namespace Meetline.Modules.SharedKernel.Domain.Tests.Wrappers;

[TestSubject(typeof(PermissionSet))]
public class PermissionSetTest
{
    [Fact(DisplayName = "None property should have no bits set")]
    public void None_ShouldHaveNoBitsSet()
    {
        var sut = PermissionSet.None;

        Assert.False(sut.Has(0));
        Assert.False(sut.Has(1));
        Assert.False(sut.Has(100));
    }

    [Theory(DisplayName = "Add() should set the specified permission and return a new instance")]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(63)]
    [InlineData(256)]
    public void Add_ShouldSetPermissionAndReturnNewInstance(int bitIndex)
    {
        var initial = PermissionSet.None;
        var updated = initial.Add(bitIndex);

        Assert.False(initial.Has(bitIndex));
        Assert.True(updated.Has(bitIndex));
    }

    [Fact(DisplayName = "Remove() should unset the specified permission and return a new instance")]
    public void Remove_ShouldUnsetPermissionAndReturnNewInstance()
    {
        var sut = PermissionSet.None.Add(5).Add(10);

        var updated = sut.Remove(5);

        Assert.True(sut.Has(5));
        Assert.False(updated.Has(5));
        Assert.True(updated.Has(10));
    }

    [Fact(DisplayName = "Has() should return true only for bits that are set")]
    public void Has_ShouldReturnTrueOnlyForSetBits()
    {
        var sut = PermissionSet.None.Add(42);

        Assert.True(sut.Has(42));
        Assert.False(sut.Has(41));
        Assert.False(sut.Has(43));
    }

    [Fact(DisplayName = "FromBytes() and ToByteArray() should correctly round-trip data")]
    public void FromBytes_ToByteArray_ShouldRoundTrip()
    {
        var expectedBytes = new byte[] { 0b10101010, 0b01010101, 0b11111111 };

        var sut = PermissionSet.FromBytes(expectedBytes);
        var actualBytes = sut.ToByteArray();

        Assert.Equal(expectedBytes, actualBytes);
    }

    [Fact(DisplayName = "FromBitArray() and ToBitArray() should correctly round-trip data")]
    public void FromBitArray_ToBitArray_ShouldRoundTrip()
    {
        var originalBits = new BitArray(new[] { true, false, true, true, false });

        var sut = PermissionSet.FromBitArray(originalBits);
        var roundTripBits = sut.ToBitArray();

        Assert.True(sut.Has(0));
        Assert.False(sut.Has(1));
        Assert.True(sut.Has(2));
        Assert.True(sut.Has(3));
        Assert.False(sut.Has(4));

        for (var i = 0; i < originalBits.Length; i++) Assert.Equal(originalBits[i], roundTripBits[i]);
    }

    [Fact(DisplayName = "Bitwise OR (|) operator should combine bits from both sets")]
    public void OperatorOr_ShouldCombineBits()
    {
        var set1 = PermissionSet.None.Add(1).Add(3);
        var set2 = PermissionSet.None.Add(2).Add(3);

        var result = set1 | set2;

        Assert.True(result.Has(1));
        Assert.True(result.Has(2));
        Assert.True(result.Has(3));
        Assert.False(result.Has(4));
    }

    [Fact(DisplayName = "Bitwise AND (&) operator should keep only shared bits")]
    public void OperatorAnd_ShouldKeepOnlySharedBits()
    {
        var set1 = PermissionSet.None.Add(1).Add(3);
        var set2 = PermissionSet.None.Add(2).Add(3);

        var result = set1 & set2;

        Assert.False(result.Has(1));
        Assert.False(result.Has(2));
        Assert.True(result.Has(3));
    }

    [Fact(DisplayName = "Bitwise XOR (^) operator should toggle differing bits")]
    public void OperatorXor_ShouldToggleDifferingBits()
    {
        var set1 = PermissionSet.None.Add(1).Add(3);
        var set2 = PermissionSet.None.Add(2).Add(3);

        var result = set1 ^ set2;

        Assert.True(result.Has(1));
        Assert.True(result.Has(2));
        Assert.False(result.Has(3));
    }

    [Fact(DisplayName = "Bitwise NOT (~) operator should invert all bits")]
    public void OperatorNot_ShouldInvertBits()
    {
        var set = PermissionSet.None.Add(0);

        var inverted = ~set;

        Assert.False(inverted.Has(0));
        Assert.True(inverted.Has(1));
        Assert.True(inverted.Has(10));
        Assert.True(inverted.Has(100));
    }

    [Fact(DisplayName = "Equality and inequality operators should work correctly based on state")]
    public void Equality_ShouldWorkCorrectlyForRecordStruct()
    {
        var set1 = PermissionSet.None.Add(5).Add(10);
        var set2 = PermissionSet.None.Add(10).Add(5);
        var set3 = PermissionSet.None.Add(5);

        Assert.Equal(set1, set2);
        Assert.True(set1 == set2);

        Assert.NotEqual(set1, set3);
        Assert.True(set1 != set3);
    }
}