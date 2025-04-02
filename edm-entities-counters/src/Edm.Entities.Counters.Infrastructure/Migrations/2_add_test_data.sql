-- +goose Up
-- +goose StatementBegin

INSERT INTO counters (id, domain_id, name, value)
SELECT '806e3fe6-3bda-4e94-a59d-bb78dd4ffc0f',
       '8a3d776c-906a-4de2-9c20-1df638f1545b',
       'Глобальный_идентификатор_1',
       0 WHERE NOT EXISTS (SELECT 1
                  FROM counters
                  WHERE id = '806e3fe6-3bda-4e94-a59d-bb78dd4ffc0f');

-- +goose StatementEnd

-- +goose Down
