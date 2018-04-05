CREATE VIEW "WinStagesCount" AS
SELECT 
  "Events"."StageEnd"."Date",
  Count("Parameters"."StageEnd"."Win") * 10 AS "Count"
FROM 
  "Parameters"."StageEnd", 
  "Events"."StageEnd"
WHERE 
  "Events"."StageEnd"."ParametersId" = "Parameters"."StageEnd"."Id" and
  "Parameters"."StageEnd"."Win" = true
GROUP BY 
  "Events"."StageEnd"."Date";
