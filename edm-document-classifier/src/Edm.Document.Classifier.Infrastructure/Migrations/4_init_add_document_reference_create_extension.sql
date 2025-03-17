-- +goose Up
-- +goose StatementBegin
create
extension pg_trgm;

-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
SELECT 'down SQL query';
-- +goose StatementEnd
