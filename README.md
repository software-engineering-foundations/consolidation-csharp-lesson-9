# Lesson 9 Independent Challenges

## Challenge 1: `BinarySearch` (12 points)

Implement a binary search algorithm that returns the index of a target number in a sorted list, otherwise raising a `InvalidOperationException` with the following exact text if the target number is not found:

```
Target not found in list
```

8 points are available for passing tests, and 4 points are available for a fully accurate $O(\log{n})$ implementation.

## Challenge 2: `SelectionSort` (12 points)

Implement a selection sort algorithm that sorts a given list of numbers in-place.

8 points are available for passing tests, and 4 points are available for a fully accurate $O(n^2)$ implementation.

## Challenge 3: `InsertionSort` (12 points)

Implement an insertion sort algorithm that sorts a given list of numbers in-place.

8 points are available for passing tests, and 4 points are available for a fully accurate $O(n^2)$ implementation.

## Challenge 4: `TwoNumberSum` (14 points)

Write a function which, given a set of numbers and a target sum, returns a new set containing a set for each pair of numbers in the original set that add up to the target sum.

10 points are available for passing tests, and 4 points are available for a fully accurate $O(n)$ implementation.

## Challenge 5: `ThreeNumberSum` (14 points)

Write a function which, given a set of numbers and a target sum, returns a new set containing a set for each triple of numbers in the original set that add up to the target sum.

10 points are available for passing tests, and 4 points are available for a fully accurate $O(n^2)$ implementation.

## Challenge 6: `ContainsTriples` (16 points)

Write a function which, given a list of numbers, returns whether the list contains any instances of the same number occurring three or more times.

12 points are available for passing tests, and 4 points are available for a fully accurate $O(n)$ implementation.

## Challenge 7: `GroupAnagrams` (20 points)

Write a function which, given a list of words, returns a set containing a set for each subset of the original words that are anagrams of each other.

For example, the function would organise the input list `["are", "era", "rat", "tar"]` as follows:

```csharp
new HashSet<HashSet<string>>({
    new HashSet<string>({"are", "era"}),
    new HashSet<string>({"rat", "tar"}),
})
```

16 points are available for passing tests, and 4 points are available for a fully accurate $O(n)$ implementation. You may assume that no words in the list are more than 10 characters in length, and that the word length therefore doesn't factor into the overall time complexity.
