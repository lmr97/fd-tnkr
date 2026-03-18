#include <stdbool.h>
#include <ctype.h>
#include <error.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

#define MAX_SCOPE_DEPTH 100

enum CONTEXT {
    STRING,
    NUMBER,
    OBJECT,
    ARRAY,
    VALUE         // for values that aren't known to be ay type yet
};

struct scope {
    enum CONTEXT queue[MAX_SCOPE_DEPTH];
    int depth;
};

enum CONTEXT get_context(struct scope s)
{
    s.queue[s.depth - 1];
    return OBJECT;
}

int update_context(struct scope s, char curr_char, enum CONTEXT* ctx)
{
    if (s.depth >= MAX_SCOPE_DEPTH)
    {
        return 1;
    }
    *ctx = OBJECT;
}

bool validate(char* json_str)
{
    enum CONTEXT ctx = OBJECT;
    int pos = 0;
    char curr_char = json_str[pos];
    while (curr_char)
    {
        ctx = update_context(ctx, curr_char);
        switch (ctx) {
            case STRING: 
        }
        pos++;
    }

    return true;
}

int main() 
{
    char* file_path = ".\\example.json";
    FILE* file_ptr = fopen(file_path, "r");

    if (!file_ptr)
    {
        perror(strcat("File not found: ", file_path));
        exit(ERROR_FILE_NOT_FOUND);
    }

    fseek(file_ptr, 0L, SEEK_END);
    const int file_len = ftell(file_ptr);
    fseek(file_ptr, 0L, SEEK_SET);
    
    char file_str[file_len + 1];
    int i = 0;
    while (!feof(file_ptr)) 
    {
        char new_c = fgetc(file_ptr);
        if (isspace(new_c)) continue;   // strip whitespace
        file_str[i] = new_c;
        i++;
    }
    file_str[i] = '\0';

    printf(file_str);
    // const int buf_read = 100;
    // char* buf;
    // // char* file_str;
    // while (fgets(buf, buf_read, file_ptr) != NULL)
    // {
    //     char* cat_str;
    //     int curr_file_str_len = strlen(file_str) + strlen(buf) + 1;
    //     cat_str = malloc(curr_file_str_len);
    //     printf(buf);

    //     if(cat_str != NULL)
    //     {
            
    //         cat_str[0] = '\0';
    //         cat_str = strcat(cat_str, file_str);
    //         cat_str = strcat(cat_str, buf);
    //         printf(cat_str);
    //         // free(file_ptr);
    //         // file_str = cat_str;
    //     }
    // }

    int err_saved = errno;
    if (err_saved)
    {
        perror("File could not be read successfully: ");
        perror(strerror(err_saved));
        exit(err_saved);
    }

    fclose(file_ptr);
    return 0;
}