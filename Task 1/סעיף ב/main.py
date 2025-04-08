import pandas as pd

#1
# df = pd.read_excel("C:\\Users\\user1\\Desktop\\Hadasim\\Task 1\\time_series.xlsx")
#
# df['timestamp'] = pd.to_datetime(df['timestamp'], errors='coerce')
#
# df.dropna(subset=['timestamp', 'value'], inplace=True)
#
# df.drop_duplicates(inplace=True)
#
# df['value'] = pd.to_numeric(df['value'], errors='coerce')
# df.dropna(subset=['value'], inplace=True)
#
# df['hour'] = df['timestamp'].dt.floor('H')
#
# hourly_avg = df.groupby('hour')['value'].mean().reset_index()
#
# hourly_avg.columns = ['זמן התחלה', 'ממוצע']
#
# print(hourly_avg)

#2
# import os
# file_path = r"C:\Users\user1\Desktop\Hadasim\Task 1\time_series.xlsx"
#
# if file_path.endswith(".xlsx"):
#     df = pd.read_excel(file_path)
# elif file_path.endswith(".csv"):
#     df = pd.read_csv(file_path)
# else:
#     raise ValueError("פורמט קובץ לא נתמך")
#
# df['timestamp'] = pd.to_datetime(df['timestamp'], errors='coerce')
# df['value'] = pd.to_numeric(df['value'], errors='coerce')
# df.dropna(subset=['timestamp', 'value'], inplace=True)
#
# df['date'] = df['timestamp'].dt.date
# output_dir = "daily_parts"
# os.makedirs(output_dir, exist_ok=True)
#
# for date, group in df.groupby('date'):
#     group.to_excel(f"{output_dir}/{date}.xlsx", index=False)
#
# print(" פיצול לקבצים יומיים הושלם.")
#
# all_hourly = []
#
# for file in os.listdir(output_dir):
#     if file.endswith(".xlsx"):
#         daily_df = pd.read_excel(os.path.join(output_dir, file))
#         daily_df['timestamp'] = pd.to_datetime(daily_df['timestamp'], errors='coerce')
#         daily_df['value'] = pd.to_numeric(daily_df['value'], errors='coerce')
#         daily_df.dropna(subset=['timestamp', 'value'], inplace=True)
#
#         daily_df['hour'] = daily_df['timestamp'].dt.floor('h')
#
#         hourly = daily_df.groupby('hour')['value'].mean().reset_index()
#         all_hourly.append(hourly)
#
# final_df = pd.concat(all_hourly).sort_values('hour').reset_index(drop=True)
# final_df.columns = ['זמן התחלה', 'ממוצע']
#
# final_df.to_excel("final_hourly_averages.xlsx", index=False)
# print(" נוצר הקובץ: final_hourly_averages.xlsx")

#3
# from collections import defaultdict
# import datetime
#
# # שמירה של סכום ומספר ערכים לכל שעה
# hourly_data = defaultdict(lambda: {'sum': 0.0, 'count': 0})
#
# def process_new_value(timestamp_str, value):
#     timestamp = pd.to_datetime(timestamp_str)
#     hour = timestamp.floor('h')  # נרמול לשעה שלמה
#
#     hourly_data[hour]['sum'] += value
#     hourly_data[hour]['count'] += 1
#
#     avg = hourly_data[hour]['sum'] / hourly_data[hour]['count']
#     print(f"שעה: {hour}, ממוצע עדכני: {avg:.2f}")
#
# process_new_value("2025-06-10 06:10:00", 15.3)
# process_new_value("2025-06-10 06:55:00", 5.3)
# process_new_value("2025-06-10 07:34:00", 12.6)
# process_new_value("2025-06-10 07:49:00", 3.2)

#4
import pandas as pd

df = pd.read_parquet("C:\\Users\\user1\\Desktop\\Hadasim\\Task 1\\time_series (4).parquet")

df['timestamp'] = pd.to_datetime(df['timestamp'], errors='coerce')

df.dropna(subset=['timestamp', 'mean_value'], inplace=True)

df['mean_value'] = pd.to_numeric(df['mean_value'], errors='coerce')

df.dropna(subset=['mean_value'], inplace=True)

df['hour'] = df['timestamp'].dt.floor('h')

hourly_avg = df.groupby('hour')['mean_value'].mean().reset_index()

hourly_avg.columns = ['זמן התחלה', 'ממוצע']

print(hourly_avg)

hourly_avg.to_csv("final_hourly_averages.csv", index=False)
