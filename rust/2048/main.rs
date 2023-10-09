use std::io::{self, Write};

fn main() {
    let mut board = [[0; 4]; 4];
    for r in 0..4 {
        let mut input = String::new();
        io::stdin().read_line(&mut input).expect("Failed to read line");
        let nums: Vec<i32> = input
            .trim()
            .split_whitespace()
            .map(|s| s.parse().unwrap())
            .collect();

        for (c, &num) in nums.iter().enumerate() {
            board[r][c] = num;
        }
    }

    let mut dir_input = String::new();
    io::stdin().read_line(&mut dir_input).expect("Failed to read line");
    let dir = dir_input.trim();

    match dir {
        "0" => print_board(left(board)),
        "1" => print_board(up(board)),
        "2" => print_board(right(board)),
        _ => print_board(down(board)),
    }
}

fn left(mut arr: [[i32; 4]; 4]) -> [[i32; 4]; 4] {
    for r in 0..4 {
        let mut swap = [false; 4];
        for c in 1..4 {
            if arr[r][c] == 0 {
                continue;
            }
            let mut C = c;
            while C > 0 {
                if arr[r][C - 1] == 0 {
                    arr[r][C - 1] = arr[r][C];
                    arr[r][C] = 0;
                    swap.swap(C, C - 1);
                } else if arr[r][C - 1] == arr[r][C] && !swap[C] && !swap[C - 1] {
                    arr[r][C - 1] <<= 1;
                    arr[r][C] = 0;
                    swap[C - 1] = true;
                    break;
                } else {
                    break;
                }
                C -= 1;
            }
        }
    }
    arr
}

fn right(arr: [[i32; 4]; 4]) -> [[i32; 4]; 4] {
    let rotated = rotate(rotate(arr));
    let left_transformed = left(rotated);
    rotate(rotate(left_transformed))
}

fn up(arr: [[i32; 4]; 4]) -> [[i32; 4]; 4] {
    let rotated = rotate(rotate(rotate(arr)));
    let left_transformed = left(rotated);
    rotate(rotate(rotate(left_transformed)))
}

fn down(arr: [[i32; 4]; 4]) -> [[i32; 4]; 4] {
    let rotated = rotate(arr);
    let left_transformed = left(rotated);
    rotate(rotate(rotate(left_transformed)))
}

fn rotate(arr: [[i32; 4]; 4]) -> [[i32; 4]; 4] {
    let mut temp = [[0; 4]; 4];
    for c in (0..4).rev() {
        for r in 0..4 {
            temp[3 - c][r] = arr[r][c];
        }
    }
    temp
}

fn print_board(arr: [[i32; 4]; 4]) {
    for row in &arr {
        for &x in row {
            print!("{} ", x);
        }
        println!();
    }
}