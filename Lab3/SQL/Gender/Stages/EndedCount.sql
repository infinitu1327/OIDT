CREATE TABLE public.stages_ended_count AS
SELECT 
  date,
  COUNT(*) * 10 AS count
FROM 
  events.stage_end
GROUP BY
  date
ORDER BY
  date;