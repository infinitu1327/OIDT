CREATE VIEW public."DAU" AS
SELECT 
  "Date",
  Count(*)*10 AS "Count"
FROM 
  "Events"."FirstLaunch"
GROUP BY 
  "Date";