using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository heroRepository;
    private Hero hero1;
    private Hero hero2;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
        hero1 = new Hero("Ivan", 69);
        hero2 = new Hero("Pavlin", 420);
    }

    [Test]
    public void ConstructorShouldSetCorrectly()
    {
        var test = new HeroRepository();

        Assert.IsNotNull(test);
    }

    [Test]
    public void CreateShouldAddHero()
    {
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        int expected = 2;

        Assert.AreEqual(expected, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateThrowsExceptionIfHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void CreateThrowsExceptionIfHeroIsExisting()
    {
        heroRepository.Create(hero1);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(new Hero("Ivan", 123)));
    }

    [Test]
    public void RemoveShouldRemoveCorrectly()
    {
        heroRepository.Create(hero1);

        Assert.IsTrue(heroRepository.Remove("Ivan"));
    }

    [Test]
    public void RemoveShouldThrowExceptionIfNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }

    [Test]
    public void GetHeroWithHighestLvlShouldReturnCorrectHero()
    {
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        var expected = hero2;
        
        Assert.AreEqual(expected, heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroReturnsCorrectHero()
    {
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        var expected = hero1;

        Assert.AreEqual(expected, heroRepository.GetHero("Ivan"));
    }

    [Test]
    public void HeroesReturnExactCollection()
    {
        var collection = new List<Hero>() { hero1, hero2};
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        CollectionAssert.AreEqual(collection, heroRepository.Heroes);
    }
}