using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private Hero hero;
    private Axe axe;
    private string name;
    private int heroExperience = 0;
    private Dummy target;
    private int dummyExperience;
    private int dummyHealth;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero(name);
        target = new Dummy(dummyHealth, dummyExperience);
    }

    [Test]
    public void When_CreateNewHero_ShoudSetDefaultWeapon()
    {
        axe = new Axe(10, 10);
        Assert.That(hero.Weapon.AttackPoints,Is.EqualTo(axe.AttackPoints));
        Assert.That(hero.Weapon.DurabilityPoints,Is.EqualTo(axe.DurabilityPoints));
    }

    [Test]
    public void When_CreateNewHero_ShoudSetCorrectName()
    {
        Assert.That(hero.Name, Is.EqualTo(name));
    }

    [Test]
    public void When_CreateNewHero_ShoudSetCorrectExperience()
    {
        Assert.That(hero.Experience, Is.EqualTo(heroExperience));
    }

    [Test]
    public void When_AttackAliveDummy_ShouldNotGainExperience()
    {
        target = new Dummy(20, 10);
        hero.Attack(target);
        Assert.That(hero.Experience, Is.EqualTo(heroExperience));
    }

    [Test]
    public void When_AttackDeadDummy_ShouldGainExperience()
    {
        target = new Dummy(5, 10);
        hero.Attack(target);
        Assert.That(hero.Experience, Is.EqualTo(heroExperience+target.GiveExperience()));
    }
}