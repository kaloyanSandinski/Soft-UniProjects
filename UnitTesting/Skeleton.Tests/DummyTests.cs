using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private int health = 3;
    private int experience = 30;
    private int attackedPoints = 5;
    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
    }

    [Test]
    public void When_HealthIsProvided_ShouldBeSetCorrectly()
    {
        Assert.That(dummy.Health, Is.EqualTo(health));
    }

    [Test]
    public void When_DummyIsDeadGetExperienceIsCalled_ShouldReturnCorrectExperience()
    {
        dummy = new Dummy(-3, experience);
        Assert.That(dummy.GiveExperience(),Is.EqualTo(experience));
    }

    [Test]
    public void When_DummyIsAliveGetExperienceIsCalled_ShouldThrowException()
    {
        dummy = new Dummy(5, experience);
        Assert.That(() =>
        {
            dummy.GiveExperience();
        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }


    [Test]
    public void When_DummyIsAttacked_ShouldLoseHealth()
    {
        dummy.TakeAttack(attackedPoints);
        Assert.That(dummy.Health,Is.EqualTo(health-attackedPoints), "Health shoud be reduced by attacked points!!!");
    }

    [Test]
    public void When_AttackedDummyIsDead_ShouldThrow()
    {
        dummy = new Dummy(0, experience);
        Assert.That(() =>
        {
            dummy.TakeAttack(5);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void When_HealthIsPositive_ShouldBeAlive()
    {
        Assert.That(dummy.IsDead,Is.EqualTo(false));
    }

    [Test]
    public void When_HealthIsZero_ShouldBeDead()
    {
        dummy = new Dummy(0, experience);
        Assert.That(dummy.IsDead, Is.EqualTo(true));
    }
    [Test]
    public void When_HealthIsNegative_ShouldBeDead()
    {
        dummy = new Dummy(-5, experience);
        Assert.That(dummy.IsDead, Is.EqualTo(true));
    }
}
