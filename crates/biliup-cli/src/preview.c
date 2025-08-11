#include "video_preview.h"
#include <stdlib.h>
#include <string.h>

void preview_video(const char* filename) {
    char cmd[512];
    snprintf(cmd, sizeof(cmd), "ffplay -autoexit %s", filename);
    log_message("Starting video preview...");
    system(cmd);
    log_message("Video preview completed.");
}