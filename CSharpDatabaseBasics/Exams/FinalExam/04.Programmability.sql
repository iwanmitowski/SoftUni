CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (
	SELECT COUNT(*)
	FROM VolunteersDepartments AS vc
	JOIN Volunteers AS v ON vc.Id = v.DepartmentId
	WHERE vc.DepartmentName = @VolunteersDepartment)
END

GO

CREATE PROCEDURE usp_AnimalsWithOwnersOrNot @AnimalName VARCHAR(50)
AS
BEGIN
	SELECT 
		a.Name,
		ISNULL(o.Name, 'For adoption') AS OwnersName
	FROM Animals AS a
	LEFT JOIN Owners AS o ON o.Id = a.OwnerId
	WHERE a.Name = @AnimalName
END