CREATE VIEW public."NewUsers" AS
SELECT 
  "Date", 
  Count(DISTINCT("Udid"))*10 AS "Count"
FROM 
  "Events"."FirstLaunch" 
WHERE 
  (SELECT DISTINCT ("Udid") FROM "Events"."FirstLaunch")
GROUP BY 
  "Date";