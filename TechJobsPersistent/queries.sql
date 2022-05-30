-- Part 1: 

-- Id integer, Name longtext, EmployerId integer

-- Part 2:

SELECT Name
FROM Employers
WHERE (Location="St. Louis City");

-- Part 3

SELECT DISTINCT
    Name, Description
FROM
    techjobs.skills
        INNER JOIN
    techjobs.jobskills ON techjobs.skills.id = techjobs.jobskills.SkillId
ORDER BY name;