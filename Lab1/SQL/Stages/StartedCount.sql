CREATE TABLE public.stages_start_count AS
SELECT 
  date,
  Count(*) * 10 as count
FROM 
  events.stage_start
GROUP BY
  date
ORDER BY
  date;