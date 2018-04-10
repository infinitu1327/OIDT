CREATE TABLE public.mau AS
SELECT
  gender,
  Count(DISTINCT udid) * 10 as count
FROM 
  events.first_launch
GROUP BY
  gender