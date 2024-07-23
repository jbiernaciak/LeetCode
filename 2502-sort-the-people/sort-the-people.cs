public class Solution
{
    public string[] SortPeople(string[] names, int[] heights)
    {
        // Create a list of tuples from the names and heights arrays
        var people = names.Zip(heights, (name, height) => new { Name = name, Height = height }).ToList();
        
        // Sort the list by height in descending order
        people.Sort((x, y) => y.Height.CompareTo(x.Height));
        
        // Extract the sorted names
        return people.Select(person => person.Name).ToArray();
    }
}
