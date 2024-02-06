namespace AAD.Tests;

public class LnkListTests
{
    [Fact]
    public void Prepend_Empty()
    {
        var ll = new LnkList<int>();

        ll.Prepend(100);
        
        Assert.Equal(new[] { 100 }, ll.ToArray());
    }
    
    [Fact]
    public void Prepend_Many()
    {
        var ll = LnkList<int>.From(2, 3, 4);

        ll.Prepend(1);
        
        Assert.Equal(new[] { 1, 2, 3, 4 }, ll.ToArray());
    }
    
    [Fact]
    public void GetByIndex_Empty()
    {
        var ll = new LnkList<int>();

        Assert.Throws<IndexOutOfRangeException>(() => ll[1]);
    }
    
    [Fact]
    public void GetByIndex_Many()
    {
        var ll = LnkList<string>.From("Hello", "World", "Yes");
        
        var value = ll[1];
        
        Assert.Equal("World", value);
    }
    
    [Fact]
    public void GetByIndex_IndexOutOfRange()
    {
        var ll = LnkList<string>.From("Hello", "World", "Yes");
        
        Assert.Throws<IndexOutOfRangeException>(() => ll[50]);
    }

    [Fact]
    public void Add_Empty()
    {
        var ll = new LnkList<string>();

        ll.Add("One");
        
        Assert.Equal(new[] { "One" }, ll.ToArray());
    }

    [Fact]
    public void Add_Many()
    {
        var ll = LnkList<int>.From(1, 2, 3);

        ll.Add(4);
        
        Assert.Equal(new[] { 1, 2, 3, 4 }, ll.ToArray());
    }

    [Fact]
    public void Insert_Empty()
    {
        var ll = new LnkList<string>();

        ll.Insert(0, "Juan");
        
        Assert.Equal(Array.Empty<string>(), ll.ToArray());
    }

    [Fact]
    public void Insert_OneElement()
    {
        var ll = LnkList<string>.From("Pablo");

        ll.Insert(0, "Juan");
        
        Assert.Equal(new[] { "Juan", "Pablo" }, 
            ll.ToArray());
    }

    [Fact]
    public void Insert_Many()
    {
        var ll = LnkList<string>.From("Juan", "Duarte");

        ll.Insert(1, "Pablo");
        
        Assert.Equal(new[] { "Juan", "Pablo", "Duarte" }, 
            ll.ToArray());
    }
    
    [Fact]
    public void Remove_EmptyList()
    {
        var ll = new LnkList<string>();

        Assert.False(ll.Remove("Hello"));
    }
    
    [Fact]
    public void Remove_One()
    {
        var ll = LnkList<string>.From("Hello");

        var result = ll.Remove("Hello");
        
        Assert.True(result);
        
        Assert.Equal(Array.Empty<string>(), ll.ToArray());
    }
    
    [Fact]
    public void Remove_LastOfTwo()
    {
        var ll = LnkList<string>.From("A", "B");

        var result = ll.Remove("B");
        
        Assert.True(result);
        
        Assert.Equal(new[] { "A" }, ll.ToArray());
    }
    
    [Fact]
    public void Remove_Many()
    {
        var ll = LnkList<string>.From("Bread", "Ham", "Butter");

        var result = ll.Remove("Ham");
        
        Assert.True(result);
        
        Assert.Equal(new[] { "Bread", "Butter" }, ll.ToArray());
    }
    
    [Fact]
    public void Remove_DoesNotExists_Empty()
    {
        var ll = new LnkList<string>();

        var result = ll.Remove("Ghost");
        
        Assert.False(result);
    }
    
    [Fact]
    public void Remove_DoesNotExists_One()
    {
        var ll = LnkList<string>.From("A");

        var result = ll.Remove("B");
        
        Assert.False(result);
    }
    
    [Fact]
    public void Remove_DoesNotExists_Many()
    {
        var ll = LnkList<string>.From("A", "B", "C");

        var result = ll.Remove("D");
        
        Assert.False(result);
    }
    
    [Fact]
    public void Count_Empty()
    {
        var ll = new LnkList<int>();
        
        Assert.Equal(0, ll.Count());
    }

    [Fact]
    public void Count_Many()
    {
        var ll = LnkList<int>.From(1, 2, 3, 4);
        
        Assert.Equal(4, ll.Count());
    }

    [Fact]
    public void From()
    {
        var ll = LnkList<int>.From(1, 2, 3);
        
        Assert.Equal(new[] { 1, 2, 3 }, ll.ToArray());
    }

    [Fact]
    public void ToArray_Empty()
    { 
        var ll = new LnkList<int>();

        Assert.Equal(Array.Empty<int>(), ll.ToArray());
    }

    [Fact]
    public void ToArray_OneElement()
    {
        var ll = LnkList<int>.From(1);;

        Assert.Equal(new[] { 1 }, ll.ToArray());
    }

    [Fact]
    public void ToArray_TwoElements()
    {
        var ll = LnkList<int>.From(1, 2);;

        Assert.Equal(new[] { 1, 2 }, ll.ToArray());
    }

    [Fact]
    public void ToArray_Many()
    {
        var ll = LnkList<int>.From(1, 2, 3, 4);

        Assert.Equal(new[] { 1, 2, 3, 4 }, ll.ToArray());
    }
}