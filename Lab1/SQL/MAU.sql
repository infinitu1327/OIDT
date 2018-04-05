CREATE VIEW public."MAU" AS
SELECT 
  Count(DISTINCT "Udid") * 10 as "Count"
FROM 
  "Events"."FirstLaunch";