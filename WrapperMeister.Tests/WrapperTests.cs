namespace ToolBX.WrapperMeister.Tests;

[TestClass]
public sealed class WrapperTests : Tester
{
    public sealed class Garbage
    {
        public string? Name { get; set; }

        public override string ToString() => $"Garbage {Name}";

        // ReSharper disable once NonReadonlyMemberInGetHashCode : For testing purposes
        public override int GetHashCode() => Name?.GetHashCode() ?? 0;
    }

    public sealed class GarbageWrapper(Garbage unwrapped) : Wrapper<Garbage>(unwrapped)
    {
        public string? Name
        {
            get => Unwrapped.Name;
            set => Unwrapped.Name = value;
        }
    }

    [TestMethod]
    public void Constructor_WhenUnwrappedIsNull_Throw()
    {
        //Arrange

        //Act
        var action = () => new GarbageWrapper(null!);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName("unwrapped");
    }

    [TestMethod]
    public void Constructor_WhenUnwrappedIsNotNull_DoNotThrow()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();

        //Act
        var action = () => new GarbageWrapper(unwrapped);

        //Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void Unwrapped_Always_ReturnsWrappedObject()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper.Unwrapped;

        //Assert
        result.Should().BeSameAs(unwrapped);
    }

    [TestMethod]
    public void Equals_WhenComparingWithSameUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper.Equals(unwrapped);

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_WhenComparingWithDifferentUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        var otherUnwrapped = Dummy.Create<Garbage>();

        //Act
        var result = wrapper.Equals(otherUnwrapped);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void Equals_WhenComparingWithOtherWrapperWithSameUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        var otherWrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper.Equals(otherWrapper);

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_WhenComparingWithOtherWrapperWithDifferentUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        var otherWrapper = new GarbageWrapper(Dummy.Create<Garbage>());

        //Act
        var result = wrapper.Equals(otherWrapper);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualsObject_WhenComparingWithSameUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        // ReSharper disable once SuspiciousTypeConversion.Global : For testing purposes
        var result = wrapper.Equals((object)unwrapped);

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void EqualsObject_WhenComparingWithDifferentUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        object otherUnwrapped = Dummy.Create<Garbage>();

        //Act
        var result = wrapper.Equals(otherUnwrapped);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualsObject_WhenComparingWithOtherWrapperWithSameUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        object otherWrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper.Equals(otherWrapper);

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void EqualsObject_WhenComparingWithOtherWrapperWithDifferentUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        object otherWrapper = new GarbageWrapper(Dummy.Create<Garbage>());

        //Act
        var result = wrapper.Equals(otherWrapper);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualityOperator_WhenComparingWithSameUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper == unwrapped;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void EqualityOperator_WhenComparingWithDifferentUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        var otherUnwrapped = Dummy.Create<Garbage>();

        //Act
        var result = wrapper == otherUnwrapped;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualityOperator_WhenComparingWithOtherWrapperWithSameUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        var otherWrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper == otherWrapper;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void EqualityOperator_WhenComparingWithOtherWrapperWithDifferentUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        var otherWrapper = new GarbageWrapper(Dummy.Create<Garbage>());

        //Act
        var result = wrapper == otherWrapper;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InequalityOperator_WhenComparingWithSameUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper != unwrapped;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InequalityOperator_WhenComparingWithDifferentUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        var otherUnwrapped = Dummy.Create<Garbage>();

        //Act
        var result = wrapper != otherUnwrapped;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void InequalityOperator_WhenComparingWithOtherWrapperWithSameUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        var otherWrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper != otherWrapper;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InequalityOperator_WhenComparingWithOtherWrapperWithDifferentUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);
        var otherWrapper = new GarbageWrapper(Dummy.Create<Garbage>());

        //Act
        var result = wrapper != otherWrapper;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_WhenOtherWrapperIsNull_ReturnsFalse()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper.Equals((IWrapper<Garbage>?)null);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualsObject_WhenComparingWithUnrelatedType_ReturnsFalse()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper.Equals("some string");

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualityOperator_WhenBothWrappersAreNull_ReturnsTrue()
    {
        //Arrange
        GarbageWrapper? left = null;
        GarbageWrapper? right = null;

        //Act
        var result = left == right;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void EqualityOperator_WhenLeftWrapperIsNull_ReturnsFalse()
    {
        //Arrange
        GarbageWrapper? left = null;
        var right = new GarbageWrapper(Dummy.Create<Garbage>());

        //Act
        var result = left == right;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualityOperator_WhenRightWrapperIsNull_ReturnsFalse()
    {
        //Arrange
        var left = new GarbageWrapper(Dummy.Create<Garbage>());
        GarbageWrapper? right = null;

        //Act
        var result = left == right;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualityOperator_WhenComparingWithNullUnwrappedObject_ReturnsFalse()
    {
        //Arrange
        var wrapper = new GarbageWrapper(Dummy.Create<Garbage>());

        //Act
        var result = wrapper == (Garbage?)null;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualityOperator_WhenNullWrapperComparedWithNullUnwrappedObject_ReturnsTrue()
    {
        //Arrange
        GarbageWrapper? wrapper = null;

        //Act
        var result = wrapper == (Garbage?)null;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void InequalityOperator_WhenBothWrappersAreNull_ReturnsFalse()
    {
        //Arrange
        GarbageWrapper? left = null;
        GarbageWrapper? right = null;

        //Act
        var result = left != right;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InequalityOperator_WhenLeftWrapperIsNull_ReturnsTrue()
    {
        //Arrange
        GarbageWrapper? left = null;
        var right = new GarbageWrapper(Dummy.Create<Garbage>());

        //Act
        var result = left != right;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void InequalityOperator_WhenRightWrapperIsNull_ReturnsTrue()
    {
        //Arrange
        var left = new GarbageWrapper(Dummy.Create<Garbage>());
        GarbageWrapper? right = null;

        //Act
        var result = left != right;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void GetHashCode_Always_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper.GetHashCode();

        //Assert
        result.Should().Be(unwrapped.GetHashCode());
    }

    [TestMethod]
    public void ToString_Always_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = wrapper.ToString();

        //Assert
        result.Should().Be(unwrapped.ToString());
    }

    [TestMethod]
    public void ExplicitCastingOperator_Always_UnwrapsObject()
    {
        //Arrange
        var unwrapped = Dummy.Create<Garbage>();
        var wrapper = new GarbageWrapper(unwrapped);

        //Act
        var result = (Garbage)wrapper;

        //Assert
        result.Should().BeSameAs(unwrapped);
    }
}