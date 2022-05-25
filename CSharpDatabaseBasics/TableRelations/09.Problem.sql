USE Geography

SELECT MountainRange, PeakName, Elevation
  FROM Mountains AS m
  JOIN Peaks AS p ON m.Id = p.MountainId
 WHERE MountainRange LIKE 'Rila'
 ORDER BY Elevation DESC