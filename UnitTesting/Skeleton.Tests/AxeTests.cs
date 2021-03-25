using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private int attack = 5;
    private int durability = 5;
    private int health = 50000;
    private int experience = 40000;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {

        axe = new Axe(attack, durability);
        dummy = new Dummy(health, experience);
    }

    [Test]
    public void When_AxeIsUsed_ShouldLoseDurability()
    {

        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(durability - 1), "Axe durability doesn't change after attack");
    }

    [Test]
    public void When_AxeDurabilitiPointsAreZero_ShouldThrowException()
    {
        Assert.That(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(dummy);
            }
        }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}