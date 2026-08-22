from pathlib import Path
import sys


def count_lines(project_dir):
    project_dir = Path(project_dir)

    total_lines = 0
    total_files = 0

    for cs_file in project_dir.rglob("*.cs"):
        # Optionally skip common build/generated directories
        if any(part in {"bin", "obj"} for part in cs_file.parts):
            continue

        try:
            with cs_file.open("r", encoding="utf-8") as f:
                lines = sum(1 for _ in f)

            print(f"{lines:6}  {cs_file}")
            total_lines += lines
            total_files += 1

        except (UnicodeDecodeError, OSError) as e:
            print(f"Could not read {cs_file}: {e}", file=sys.stderr)

    print()
    print(f"Files: {total_files}")
    print(f"Lines: {total_lines}")


if __name__ == "__main__":
    project_dir = sys.argv[1] if len(sys.argv) > 1 else "."

    count_lines(project_dir)
