namespace ToolBX.WrapperMeister.Tests;

[TestClass]
public sealed class WrapperTests : Tester
{
    public sealed class Dummy
    {
        public string? Name { get; set; }

        public override string ToString() => $"Dummy {Name}";

        // ReSharper disable once NonReadonlyMemberInGetHashCode : For testing purposes
        public override int GetHashCode() => Name?.GetHashCode() ?? 0;
    }

    public sealed class DummyWrapper(Dummy unwrapped) : Wrapper<Dummy>(unwrapped)
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
        var action = () => new DummyWrapper(null!);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName("unwrapped");
    }

    [TestMethod]
    public void Constructor_WhenUnwrappedIsNotNull_DoNotThrow()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();

        //Act
        var action = () => new DummyWrapper(unwrapped);

        //Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void Unwrapped_Always_ReturnsWrappedObject()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper.Unwrapped;

        //Assert
        result.Should().BeSameAs(unwrapped);
    }

    [TestMethod]
    public void Equals_WhenComparingWithSameUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper.Equals(unwrapped);

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_WhenComparingWithDifferentUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        var otherUnwrapped = Fixture.Create<Dummy>();

        //Act
        var result = wrapper.Equals(otherUnwrapped);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void Equals_WhenComparingWithOtherWrapperWithSameUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        var otherWrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper.Equals(otherWrapper);

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_WhenComparingWithOtherWrapperWithDifferentUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        var otherWrapper = new DummyWrapper(Fixture.Create<Dummy>());

        //Act
        var result = wrapper.Equals(otherWrapper);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualsObject_WhenComparingWithSameUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);

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
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        object otherUnwrapped = Fixture.Create<Dummy>();

        //Act
        var result = wrapper.Equals(otherUnwrapped);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualsObject_WhenComparingWithOtherWrapperWithSameUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        object otherWrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper.Equals(otherWrapper);

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void EqualsObject_WhenComparingWithOtherWrapperWithDifferentUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        object otherWrapper = new DummyWrapper(Fixture.Create<Dummy>());

        //Act
        var result = wrapper.Equals(otherWrapper);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualityOperator_WhenComparingWithSameUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper == unwrapped;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void EqualityOperator_WhenComparingWithDifferentUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        var otherUnwrapped = Fixture.Create<Dummy>();

        //Act
        var result = wrapper == otherUnwrapped;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void EqualityOperator_WhenComparingWithOtherWrapperWithSameUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        var otherWrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper == otherWrapper;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void EqualityOperator_WhenComparingWithOtherWrapperWithDifferentUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        var otherWrapper = new DummyWrapper(Fixture.Create<Dummy>());

        //Act
        var result = wrapper == otherWrapper;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InequalityOperator_WhenComparingWithSameUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper != unwrapped;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InequalityOperator_WhenComparingWithDifferentUnwrappedObject_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        var otherUnwrapped = Fixture.Create<Dummy>();

        //Act
        var result = wrapper != otherUnwrapped;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void InequalityOperator_WhenComparingWithOtherWrapperWithSameUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        var otherWrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper != otherWrapper;

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InequalityOperator_WhenComparingWithOtherWrapperWithDifferentUnwrappedReference_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);
        var otherWrapper = new DummyWrapper(Fixture.Create<Dummy>());

        //Act
        var result = wrapper != otherWrapper;

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void GetHashCode_Always_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper.GetHashCode();

        //Assert
        result.Should().Be(unwrapped.GetHashCode());
    }

    [TestMethod]
    public void ToString_Always_UsesWrappedObjectMethod()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);

        //Act
        var result = wrapper.ToString();

        //Assert
        result.Should().Be(unwrapped.ToString());
    }

    [TestMethod]
    public void ExplicitCastingOperator_Always_UnwrapsObject()
    {
        //Arrange
        var unwrapped = Fixture.Create<Dummy>();
        var wrapper = new DummyWrapper(unwrapped);

        //Act
        var result = (Dummy)wrapper;

        //Assert
        result.Should().BeSameAs(unwrapped);
    }
}