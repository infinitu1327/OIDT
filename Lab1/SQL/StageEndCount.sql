CREATE VIEW public."StageEndCount" AS
SELECT
  "Date",
  Count("Id") * 10 as "Count"
FROM 
  "Events"."StageEnd"
GROUP BY
  "Date";
