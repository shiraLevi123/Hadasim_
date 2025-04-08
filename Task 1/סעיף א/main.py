#סעיף א
import pandas as pd

df = pd.read_excel(r"C:\Users\user1\Desktop\Hadasim\Task 1\logs.txt.xlsx", header=None)

#משימה 1

rows_of_file = 150000

for i, chunk in enumerate(range(0, len(df), rows_of_file)):
    df_chunk = df.iloc[chunk:chunk + rows_of_file]
    chunk_file = f"logs_part_{i+1}.xlsx"
    df_chunk.to_excel(chunk_file, index=False, header=False)
    print(f"נשמר קובץ: {chunk_file}")

#משימה 2

import glob

error_counter = {}

files = glob.glob("logs_part_*.xlsx")

for file in files:
    df = pd.read_excel(file, header=None)

    df['Error'] = df[0].str.extract(r'Error:\s*(\S+)')

    error_counts = df['Error'].value_counts()


    if not error_counts.empty:
        most_common_error = error_counts.idxmax()
        most_common_count = error_counts.max()

        print(f" קובץ: {file}")
        print(f" השגיאה הכי נפוצה: {most_common_error} ({most_common_count} פעמים)")
        print("-" * 40)

        for error, count in error_counts.items():
            error_counter[error] = error_counter.get(error, 0) + count

#משימה 3

if error_counter:
    most_common_error = max(error_counter, key=error_counter.get)
    most_common_count = error_counter[most_common_error]

    print(" השגיאה הנפוצה ביותר בכל הקבצים:")
    print(f" {most_common_error} הופיעה {most_common_count} פעמים!")
else:
    print(" לא נמצאו שגיאות כלל.")

# משימה 4

N = int(input("הכנס את מספר השגיאות השכיחות ביותר שברצונך להציג: "))
if error_counter:
    top_n_errors = sorted(error_counter.items(), key=lambda x: x[1], reverse=True)[:N]

    print(f"\n🔍 {N} השגיאות השכיחות ביותר:")
    for error, count in top_n_errors:
        print(f" {error} הופיעה {count} פעמים.")
else:
    print(" לא נמצאו שגיאות כלל.")

"""
n: מספר השורות בקובץ הראשי

m: מספר הקבצים הקטנים שנוצרו

p: מספר השורות בכל קובץ קטן

k: מספר סוגי השגיאות

----------------------------

סיבוכיות משימה 1: 
זמן: O(n)
ריצה: O(n)

סיבוכיות משימה 2: 
זמן: O(m * p)
זמן: O(p)

סיבוכיות משימה 3: 
זמן: O(k)
ריצה: O(k)

סיבוכיות משימה 2: 
זמן: O(k log k)
ריצה: O(k)

סה"כ: 

סיבוכיות זמן ריצה: O(n + m * p + k log k)

סיבוכיות מקום: O(n + m * p + k)

"""